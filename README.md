# CineCerb 🎬

> Aplicativo Desktop de IPTV com interface moderna estilo Netflix / Cyberpunk, desenvolvido em C# com .NET 10 e Avalonia UI (foco inicial em Windows com arquitetura preparada para Linux e Android).

---

## 🏗️ Estrutura Arquitetural

```text
CineCerb/
├── GEMINI.md                       # Regras e diretrizes do projeto para a IA assistente
├── CineCerb.sln                    # Solução .NET 10
│
├── src/
│   ├── CineCerb.Core/              # [Biblioteca de Classes .NET 10]
│   │   ├── Models/                 # Modelos de Domínio (Channel, Movie, Series, Account, EpgProgram)
│   │   ├── Interfaces/             # Contratos (IIptvService, IPlayerService, ITmdbService, IDatabaseService)
│   │   └── Enums/                  # StreamType, MediaType, PlaybackState
│   │
│   ├── CineCerb.Infrastructure/    # [Biblioteca de Classes .NET 10]
│   │   ├── Data/                   # SQLite DbContext / Repositórios locais
│   │   ├── Services/               # XtreamCodesService, DemoDataService, SubtitleService
│   │   ├── Media/                  # LibVlcPlayerService, DvrRecorderService, DownloadManager
│   │   └── Tmdb/                   # TmdbApiClient (Enriquecimento de pôsteres e sinopses)
│   │
│   └── CineCerb.App/               # [Avalonia UI Desktop App - .NET 10]
│       ├── Views/                  # Telas em XAML Avalonia (.axaml)
│       ├── ViewModels/             # ViewModels do CommunityToolkit.Mvvm
│       ├── Controls/               # HeroBanner, ContentCarousel, VideoPlayerOverlay
│       ├── Styles/                 # Temas Cerberus Cyber Blue, Brushes e Recursos Fluent
│       └── Assets/                 # Ícones, Logos e Imagens
```

---

## 📦 Pacotes NuGet Principais

| Pacote | Função |
| :--- | :--- |
| `Avalonia` (11.x) | Framework UI moderno, performático e multiplataforma |
| `Avalonia.Desktop` | Plataforma de execução desktop (Windows / Linux / macOS) |
| `Avalonia.Themes.Fluent` | Tema Fluent com suporte a Dark Mode e materiais translúcidos |
| `Avalonia.Fonts.Inter` | Tipografia moderna Inter integrada |
| `CommunityToolkit.Mvvm` | MVVM com Source Generators (`[ObservableProperty]`, `[RelayCommand]`) |
| `Microsoft.Extensions.DependencyInjection` | Contêiner de Injeção de Dependência |
| `LibVLCSharp.Avalonia` + `VideoLAN.LibVLC.Windows` | Motor universal de reprodução de vídeo |
| `sqlite-net-pcl` + `SQLitePCLRaw.bundle_e_sqlite3` | Banco de dados local SQLite de alta velocidade |
| `System.Text.Json` | Serialização/Deserialização de APIs de alta performance |

---

## 🚀 Próximos Passos de Desenvolvimento

1. **Passo 1**: Inicializar a estrutura da Solution `.sln` e projetos `.csproj` com .NET 10 e Avalonia UI 11.x.
2. **Passo 2**: Migrar/Adaptar `CineCerb.Core` e `CineCerb.Infrastructure` do protótipo com suporte a .NET 10.
3. **Passo 3**: Configurar Injeção de Dependência e `CommunityToolkit.Mvvm` no `CineCerb.App`.
4. **Passo 4**: Construir a identidade visual Cerberus Cyber Blue em Avalonia (estilos, paleta, janela personalizada).
5. **Passo 5**: Integrar a reprodução de vídeo com `LibVLCSharp.Avalonia`.
6. **Passo 6**: Implementar catálogo estilo Netflix (Hero Banner, Carrosséis horizontais, EPG e Modais).
