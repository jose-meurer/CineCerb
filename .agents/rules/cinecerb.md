# CineCerb - Regras de Desenvolvimento e Diretrizes do Projeto

Este arquivo define os padrões de arquitetura, papéis de pair programming e diretrizes técnicas para o projeto **CineCerb** (App de IPTV em C# .NET 10 com Avalonia UI 11.x, inicialmente focado em Windows e preparado para Linux e Android).

Consulte o arquivo principal [GEMINI.md](file:///c:/Users/Jose%20Meurer/Desktop/Gemini/CineCerb/GEMINI.md) na pasta `CineCerb` para as regras completas e detalhadas.

### Resumo Rápido da Stack:
- **Framework**: Avalonia UI (v11.x) - Desktop Standalone.
- **Runtime**: .NET 10 (SDK `10.0.401+`).
- **Arquitetura**: MVVM com `CommunityToolkit.Mvvm` e DI (`Microsoft.Extensions.DependencyInjection`).
- **Vídeo**: `LibVLCSharp.Avalonia` + `VideoLAN.LibVLC.Windows` (Decodificação universal por hardware).
- **Formatos**: Xtream Codes API + Listas M3U/M3U8 com EPG XMLTV.
- **Banco/Cache**: SQLite local (`sqlite-net-pcl`) + cache de imagens no AppData.
- **Metadados**: TMDb API para enriquecimento com capas e backdrops em alta resolução.
- **Visual**: Identidade Cerberus Cyber Blue (Dark Mode `#0a0a0d`, acento `#00D2FF`, materiais translúcidos e carrosséis horizontais com *hover zoom*).
- **Filosofia de Trabalho**: Pair programming guiado pelo usuário (líder técnico), em etapas pequenas, modulares e validadas.
