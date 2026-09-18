# Diretrizes e Regras de Desenvolvimento: CineCerb

## 1. Filosofia de Trabalho em Par (Pair Programming)
* **Papéis Definidos**:
  * **O Desenvolvedor (Usuário)**: É o líder técnico, tomador de decisões e quem comanda a evolução do projeto.
  * **A IA (Assistente Técnico)**: Atua como pair programmer sênior especializado em C#, .NET 10 e WinUI 3. A IA deve:
    * Nunca tomar decisões de arquitetura ou alterar fluxos críticos unilateralmente sem antes propor e receber o aval do Desenvolvedor.
    * Explicar o raciocínio, vantagens e desvantagens de cada implementação sugerida.
    * Dividir o trabalho em etapas pequenas, testáveis e claras, evitando "muralhas de código" sem contexto.
    * Respeitar rigorosamente o estilo, convenções e preferências instruídas pelo Desenvolvedor.
* **Isolamento Estrito de Diretório**:
  * **TUDO deve ficar dentro da pasta `CineCerb/`**: Solução (`.sln`), projetos (`.csproj`), código-fonte (`src/`), assets, documentações, testes e regras de configuração.
  * Nunca criar ou mover qualquer arquivo do projeto para fora da pasta `CineCerb/`.

---

## 2. Stack Tecnológica Oficial
* **Linguagem & Plataforma**: C# (.NET 10 LTS, SDK `10.0.401+`, TFM `net10.0-windows10.0.19041.0` ou superior).
* **Framework de Interface**: WinUI 3 (Windows App SDK) operando em modo **Unpackaged** (`<WindowsPackageType>None</WindowsPackageType>` no `.csproj` para gerar `.exe` tradicional para distribuição direta / Inno Setup).
* **Padrão de Arquitetura**: MVVM com `CommunityToolkit.Mvvm` (usando *Source Generators*: `[ObservableProperty]`, `[RelayCommand]`) e Injeção de Dependência via `Microsoft.Extensions.DependencyInjection`.
* **Motor de Reprodução de Vídeo**: `LibVLCSharp.WinUI` + binários nativos `VideoLAN.LibVLC.Windows` (suporte universal a HLS, MPEG-TS, H.264, HEVC/H.265, áudio AC3/EAC3 sem dependência de codecs do Windows).
* **Fontes de Dados**:
  * **Xtream Codes API**: Cliente HTTP assíncrono para obtenção estruturada de categorias, canais ao vivo, VOD (filmes) e séries.
  * **Listas M3U / M3U8**: Parser rápido de arquivos locais ou remotos com suporte a atributos de metadados (`tvg-id`, `tvg-name`, `tvg-logo`, `group-title`).
  * **EPG (Guia de Programação)**: Parser XMLTV assíncrono em fluxo (*streaming parser* para não estourar memória com arquivos XML gigantes).
* **Banco de Dados Local & Cache**:
  * **SQLite** (via `sqlite-net-pcl` ou `Microsoft.Data.Sqlite`) para indexação de canais, histórico de "Continuar Assistindo", favoritos e configurações.
  * **Cache de Mídia em Disco**: Cache de pôsteres e logotipos no AppData local para carregamento instantâneo e economia de banda.
* **Enriquecimento de Metadados**:
  * Integração com **TMDb API (TheMovieDB)** para obter pôsteres em alta definição, backdrops panorâmicos (1080p/4K) e sinopses ricas, com fallback automático para os dados originais do provedor IPTV.

---

## 3. Diretrizes de Design & UI/UX (Estilo Netflix)
* **Identidade Visual**:
  * Paleta Dark Mode cinematográfica: fundo preto/cinza muito escuro (`#141414` / `#0f0f0f`), detalhes translúcidos com materiais Fluent Design do Windows 11 (Mica / Acrylic).
  * Cor de destaque/acento elegante (vermelho cinematográfico ou personalizável).
* **Componentes Principais**:
  * **Hero Banner Dinâmico**: Destaque de topo com pôster panorâmico, sinopse, classificação indicativa e botões de ação ("Assistir Agora", "Mais Informações").
  * **Carrosséis Horizontais de Conteúdo**: Linhas de filmes/séries/canais organizados por gênero ("Continuar Assistindo", "Em Alta", etc.) com efeito suave de *hover zoom* (+10% de escala e elevação com sombra ao passar o mouse).
  * **Modal de Detalhes de Conteúdo**: Painel sobreposto exibindo sinopse completa, seletor de temporadas e episódios, áudios e legendas disponíveis.
  * **Grade de TV Ao Vivo (EPG)**: Linha do tempo horizontal estilo televisão moderna, exibindo o programa atual e os próximos.
* **Navegação Híbrida**:
  * Suporte nativo tanto para **Mouse/Teclado** quanto para **Controle de Xbox / Teclas Direcionais (Setas)** através do sistema de foco `XYFocus` do WinUI 3, permitindo uso em TVs de sala.

---

## 4. Recursos Avançados de Vídeo & Regras de Negócio
* **Picture-in-Picture (PiP)**: Janela de vídeo flutuante sem bordas e *Always-on-Top* para permitir que o usuário continue assistindo enquanto navega pelo catálogo ou usa outros apps.
* **Multiview**: Grade dividida em 2 ou 4 canais ao vivo simultâneos com alternância instantânea da faixa de áudio ativa ao focar na tela desejada.
* **Catch-up / Timeshift**: Suporte a reprodução de conteúdos passados diretamente a partir do guia EPG (quando suportado pelo servidor Xtream Codes).
* **Gravação Local DVR**: Gravação do fluxo de transmissão ao vivo diretamente em disco (`.mp4`/`.ts`) via LibVLC.
* **Download Offline de VOD**: Fila de download assíncrona com controle de pausa/retomada para reprodução offline de filmes e séries.
* **Gerenciador Multi-Contas**:
  * Cada conta/login (servidor Xtream ou lista M3U) opera como um perfil isolado com seu próprio catálogo, histórico e favoritos.
  * Proteção por **PIN de 4 dígitos** para categorias e canais adultos (+18).

---

## 5. Padrões de Código e Boas Práticas
* **Código C# Moderno**:
  * Utilizar recursos modernos do C# 12/13 (Pattern matching, Primary Constructors onde apropriado, records para DTOs imutáveis, nullable reference types habilitados).
  * Nomenclatura: PascalCase para classes, métodos e propriedades públicas; `_camelCase` para campos privados. Interfaces sempre prefixadas com `I` (`IIptvService`, `IPlayerService`).
* **MVVM Rigoroso**:
  * As Views (`.xaml`) contêm apenas apresentação e bindings.
  * Nenhuma lógica de negócio, chamadas de rede ou queries de banco no *code-behind* (`.xaml.cs`).
  * Utilizar `[ObservableProperty]` e `[RelayCommand]` do `CommunityToolkit.Mvvm`.
* **Performance e Memória**:
  * **Virtualização de Listas**: SEMPRE utilizar virtualização de interface (`ItemsRepeater` ou `ListView` com `VirtualizingStackPanel`) ao exibir listas de canais ou filmes. Nunca instanciar milhares de cards em memória simultaneamente.
  * **Gerenciamento de Recursos (IDisposable)**: Instâncias de LibVLC, `MediaPlayer`, streams de rede e conexões SQLite devem ser devidamente liberadas no descarte de ViewModels/Views.
  * **Resiliência de Rede**: Streams de IPTV falham por instabilidade de servidores. Toda reprodução e chamada de API deve prever tratamento de timeout, tentativas de reconexão transparente e mensagens claras para o usuário.
