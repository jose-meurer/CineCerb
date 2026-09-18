# CineCerb - Regras de Desenvolvimento e Diretrizes do Projeto

Este arquivo define os padrões de arquitetura, papéis de pair programming e diretrizes técnicas para o projeto **CineCerb** (App nativo Windows de IPTV em C# .NET 10 e WinUI 3).

Consulte o arquivo principal [GEMINI.md](file:///c:/Users/Jose%20Meurer/Desktop/Gemini/CineCerb/GEMINI.md) na pasta `CineCerb` para as regras completas e detalhadas.

### Resumo Rápido da Stack:
- **Framework**: WinUI 3 (Windows App SDK) - Unpackaged (.exe tradicional).
- **Runtime**: .NET 10 LTS (SDK `10.0.401+`).
- **Arquitetura**: MVVM com `CommunityToolkit.Mvvm` e DI (`Microsoft.Extensions.DependencyInjection`).
- **Vídeo**: `LibVLCSharp.WinUI` + `VideoLAN.LibVLC.Windows` (Decodificação universal por hardware).
- **Formatos**: Xtream Codes API + Listas M3U/M3U8 com EPG XMLTV.
- **Banco/Cache**: SQLite local + cache de imagens no AppData.
- **Metadados**: TMDb API para enriquecimento com capas e backdrops em alta resolução.
- **Visual**: Estilo Netflix com tema escuro, Hero Banner, carrosséis horizontais (*hover zoom*) e suporte híbrido Mouse/Teclado/Controle.
