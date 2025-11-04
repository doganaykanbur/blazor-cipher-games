# Blazor Cipher Games

Blazor WebAssembly tabanlı kripto oyunları koleksiyonu: Playfair, Caesar, Hill, Vigenere ve Transposition.

## Başlangıç

Gereksinimler:
- .NET SDK 9.0+

Çalıştırma:
```bash
# kök dizinde
dotnet restore
dotnet run
```
Uygulama yerel dev sunucusunda açılır. Varsayılan rota Playfair sayfasıdır (`/`).

## Proje Yapısı (özet)
- `Pages/`
  - `PlayFairGame.razor` (ana sayfa – Playfair)
  - `CaesarGame.razor`
  - `HillGame.razor`
  - `VigenereGame.razor`
  - `TranspositionGame.razor`
- `Shared/`
  - `LanguageService.cs` (TR/EN metinleri)
  - `SettingsService.cs` (zorluk durumu)
  - `DifficultySwitch.razor` (zorluk seçici)
  - `CaesarCipher.cs`, `HillCipher.cs`, `VigenereCipher.cs`, `PlayfairCipher.cs`, `TranspositionCipher.cs`
- `wwwroot/`
  - `css/site.css`
  - `images/transposition.svg`

## Zorluk
- Kolay: 1 kelime
- Normal: 2 kelime
- Zor: 3 kelime

