# CineCerb 🎬

> Aplicativo Desktop Nativo Windows para IPTV com interface moderna estilo Netflix, desenvolvido em C# com .NET 10 e WinUI 3.

---

## 🏗️ Estrutura Arquitetural Proposta

```text
CineCerb/
├── GEMINI.md                       # Regras e diretrizes do projeto para a IA assistente
├── CineCerb.sln                    # Solução do .NET 10
│
├── src/
│   ├── CineCerb.Core/              # [Biblioteca de Classes .NET 10]
│   │   ├── Models/                 # Modelos de Domínio (Channel, Movie, Series, Account, EpgProgram)
│   │   ├── Interfaces/             # Contratos (IIptvService, IPlayerService, ITmdbService, IDatabaseService)
│   │   └── Enums/                  # StreamType, MediaType, PlaybackState
│   │
│   ├── CineCerb.Infrastructure/    # [Biblioteca de Classes .NET 10]
│   │   ├── Data/                   # SQLite DbContext / Repositórios locais
│   │   ├── Iptv/                   # XtreamCodesClient, M3uParser, XmlTvEpgParser
│   │   ├── Media/                  # LibVlcPlayerService, DvrRecorderService, DownloadManager
│   │   └── Tmdb/                   # TmdbApiClient (Enriquecimento de pôsteres e sinopses)
│   │
│   └── CineCerb.App/               # [WinUI 3 Desktop App - Unpackaged]
│       ├── Views/                  # Páginas (ShellView, HomeView, LiveTvView, VodView, SeriesView, DetailsView)
│       ├── ViewModels/             # ViewModels do CommunityToolkit.Mvvm
│       ├── Controls/               # HeroBanner, ContentCarousel, VideoPlayerOverlay, PiPWindow
│       ├── Styles/                 # Recursos de Cores, Brushes, Mica/Acrylic e Temas Netflix
│       └── Assets/                 # Ícones, Logos e Placeholders
```

---

## 📦 Pacotes NuGet Principais

| Pacote | Função |
| :--- | :--- |
| `Microsoft.WindowsAppSDK` | Framework WinUI 3 para Windows 10/11 |
| `CommunityToolkit.Mvvm` | MVVM moderno com Source Generators |
| `Microsoft.Extensions.DependencyInjection` | Contêiner de Injeção de Dependência |
| `LibVLCSharp.WinUI` + `VideoLAN.LibVLC.Windows` | Motor universal de reprodução de vídeo |
| `sqlite-net-pcl` | Banco de dados local SQLite de alta velocidade |
| `System.Text.Json` | Serialização/Deserialização de APIs de alta performance |

---

## 🚀 Próximos Passos (Para iniciarmos juntos):

1. **Passo 1**: Inicializar a estrutura da Solution e projetos `.csproj` com .NET 10 e WinUI 3.
2. **Passo 2**: Configurar a Injeção de Dependência e o `CommunityToolkit.Mvvm`.
3. **Passo 3**: Criar a camada de dados (Modelos de IPTV e SQLite para salvar contas/favoritos).
4. **Passo 4**: Desenvolver o cliente da Xtream Codes API e o parser de listas M3U.
5. **Passo 5**: Integrar a engine de vídeo LibVLCSharp com controles personalizados na tela.
6. **Passo 6**: Construir a interface no estilo Netflix (Hero Banner, Carrosséis horizontais, Dark Theme e navegação fluida).
