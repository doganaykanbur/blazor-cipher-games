# Blazor Cipher Games

Blazor WebAssembly tabanlı kripto oyunları koleksiyonu: Playfair, Caesar, Hill, Vigenere ve Transposition.

- Zorluk: Kolay / Normal / Zor (sağ üstte `DifficultySwitch`)
- Dil: TR / EN (sağ üstte `LangSwitch`)
- Metin: Zorluğa göre 1/2/3 kelimelik ifadeler
- Modal sonuç ekranı ve yüzde animasyonu
- Transposition için anahtar sütun sırasına göre encode/decode

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

Not: Cevap doğrulamalarında metin şifrelerinde boşluklar yok sayılır (kullanıcı boşluklu/boşluksuz yazabilir).

## Yayın (Build/Publish)
```bash
dotnet publish -c Release
```
Blazor WASM çıktısı `bin/Release/net9.0/wwwroot` altındadır. Statik barındırma ve GitHub Pages için uygundur.

## GitHub’a Yükleme (özet komutlar)
`git` ve tercihen `gh` (GitHub CLI) kurulu olmalı.

```powershell
# repo kökünde
git init
git branch -M main

# ilk commit
git add .
git commit -m "Initial: Blazor cipher games (Playfair/Caesar/Hill/Vigenere/Transposition)"

# GitHub CLI ile repo oluşturma ve push
# (repo adı doluysa farklı bir ad kullanın)
gh repo create blazor-cipher-games --public --source . --remote origin --push
```

GitHub CLI yoksa GitHub web arayüzünden repo oluşturup şu adımları kullanın:
```powershell
git remote add origin https://github.com/<kullanici-adi>/blazor-cipher-games.git
git push -u origin main
```

---
Geliştirme, ekran görüntüsü/gif ve GitHub Actions (build/Pages deploy) desteği istersen PR/issue açabilir veya buradan devam edebilirsin.
