using System;
using System.Collections.Generic;

namespace PlayfairGame
{
    public class LanguageService
    {
        public string Current { get; private set; } = "tr";
        public event Action? OnChange;

        private readonly Dictionary<string, string> tr = new()
        {
            ["vigenere_title"] = "Vigenere Cipher",
            ["result_title"] = "Sonuç",
            ["menu_playfair"] = "Playfair",
            ["menu_caesar"] = "Sezar",
            ["menu_hill"] = "Hill",
            ["menu_vigenere"] = "Vigenere",
            ["menu_transposition"] = "Transpozisyon",
            ["menu_monoalphabetic"] = "Monoalfabetik",

            ["difficulty_easy"] = "Kolay",
            ["difficulty_normal"] = "Normal",
            ["difficulty_hard"] = "Zor",

            ["start"] = "Başlat",
            ["check"] = "Kontrol Et",
            ["show_answer"] = "Cevabı Göster",

            ["encode_mode"] = "Şifreleme Modu",
            ["decode_mode"] = "Çözme Modu",
            ["keyword_label"] = "Anahtar:",
            ["shift_label"] = "Kaydırma:",
            ["encode_word"] = "Metni şifrele:",
            ["decode_word"] = "Metni çöz:",
            ["your_answer_placeholder"] = "Cevabınız...",
            ["caesar_placeholder"] = "örn. +4 veya -4",

            ["wrong_try_again"] = "Yanlış! Tekrar deneyin.",
            ["didnt_guess"] = "Tahmin etmediniz!",
            ["continue"] = "Devam",
            ["error_count"] = "Hata Sayısı:",
            ["total_attempts"] = "Toplam Deneme:",
            ["correct_answer"] = "Doğru Cevap:",
            ["find_shift"] = "Dönüşümü sağlayan kaydırmayı (+/-) bulun",

            ["performance_perfect"] = "MÜKEMMEL!",
            ["performance_good"] = "İYİ!",
            ["performance_medium"] = "ORTA",
            ["performance_bad"] = "ZAYIF",

            ["hill_tagline"] = "Matrislerle şifreleri çözün.",
            ["hill_intro"] = "Hill, 2x2 anahtar matrisiyle harfleri şifreler. Oynayarak öğrenin.",
            ["hill_start_cta"] = "İlk mesajınızı şifrelemek için Başlat'a tıklayın!",
            ["hill_title"] = "Hill Cipher",

            ["playfair_tagline"] = "Klasik kriptografiyi oyunlarla keşfedin.",
            ["playfair_intro"] = "Playfair, çift harflerle çalışır. 5x5 matriste harfleri dönüştürür.",
            ["playfair_start_cta"] = "Başlamak için Başlat'a tıklayın ve ilk bulmaca!",
            ["playfair_title"] = "Playfair Cipher",

            ["caesar_tagline"] = "Kaydırmalı şifrelemeyle ısın.",
            ["caesar_intro"] = "Caesar, harfleri sabit bir miktar kaydırır. Doğru kaydırmayı bulun.",
            ["caesar_start_cta"] = "Başlat'a tıklayın ve deneyin!",
            ["caesar_title"] = "Caesar Cipher",

            ["vigenere_tagline"] = "Anahtar kelimeyle çoklu kaydırma.",
            ["vigenere_intro"] = "Vigenere, tekrar eden anahtar kelimeye göre harfleri kaydırır.",
            ["vigenere_start_cta"] = "Başlamak için Başlat'a tıklayın!",
            ["vigenere_title"] = "Vigenere Cipher",

            ["transposition_tagline"] = "Sütun yer değiştirme ile karıştır.",
            ["transposition_intro"] = "Anahtar kelime sütun sırasını belirler; metni şifreleyin ya da çözün.",
            ["transposition_start_cta"] = "Başlamak için Başlat'a tıklayın!",
            ["transposition_title"] = "Transposition Cipher",

            ["plain_alphabet"] = "Düz Alfabe",
            ["mixed_alphabet"] = "Karışık Alfabe",

            ["mono_tagline"] = "Karıştırılmış alfabe ile yerine koyma.",
            ["mono_intro"] = "Anahtar kelime ile üretilen karışık alfabeyi kullanarak metni şifreleyin ya da çözün.",
            ["mono_start_cta"] = "Başlamak için Başlat'a tıklayın!",
            ["mono_title"] = "Monoalphabetic Cipher",
        };

        private readonly Dictionary<string, string> en = new()
        {
            ["vigenere_title"] = "Vigenere Cipher",
            ["result_title"] = "Result",
            ["menu_playfair"] = "Playfair",
            ["menu_caesar"] = "Caesar",
            ["menu_hill"] = "Hill",
            ["menu_vigenere"] = "Vigenere",
            ["menu_transposition"] = "Transposition",
            ["menu_monoalphabetic"] = "Monoalphabetic",

            ["difficulty_easy"] = "Easy",
            ["difficulty_normal"] = "Normal",
            ["difficulty_hard"] = "Hard",

            ["start"] = "Start",
            ["check"] = "Check",
            ["show_answer"] = "Show Answer",

            ["encode_mode"] = "Encode Mode",
            ["decode_mode"] = "Decode Mode",
            ["keyword_label"] = "Keyword:",
            ["shift_label"] = "Shift:",
            ["encode_word"] = "Encode the text:",
            ["decode_word"] = "Decode the text:",
            ["your_answer_placeholder"] = "Your answer...",
            ["caesar_placeholder"] = "e.g., +4 or -4",

            ["wrong_try_again"] = "Wrong! Try again.",
            ["didnt_guess"] = "You didn't guess!",
            ["continue"] = "Continue",
            ["error_count"] = "Error Count:",
            ["total_attempts"] = "Total Attempts:",
            ["correct_answer"] = "Correct Answer:",
            ["find_shift"] = "Find the shift (+/-) that converts",

            ["performance_perfect"] = "PERFECT!",
            ["performance_good"] = "GOOD!",
            ["performance_medium"] = "MEDIUM",
            ["performance_bad"] = "BAD",

            ["hill_tagline"] = "Break ciphers with the power of matrices.",
            ["hill_intro"] = "Hill Cipher encrypts using a 2x2 key matrix modulo 26. Learn by playing.",
            ["hill_start_cta"] = "Click Start to encrypt your first message!",
            ["hill_title"] = "Hill Cipher",

            ["playfair_tagline"] = "Explore classic cryptography with interactive games.",
            ["playfair_intro"] = "Playfair works with digraphs within a 5x5 matrix.",
            ["playfair_start_cta"] = "Click Start to begin and solve your first puzzle!",
            ["playfair_title"] = "Playfair Cipher",

            ["caesar_tagline"] = "Warm up with shift-based encryption.",
            ["caesar_intro"] = "Caesar shifts each letter by a fixed amount. Find the correct shift.",
            ["caesar_start_cta"] = "Click Start to try your first encryption!",
            ["caesar_title"] = "Caesar Cipher",

            ["vigenere_tagline"] = "Keyword-based polyalphabetic cipher.",
            ["vigenere_intro"] = "Vigenere shifts letters according to a repeating keyword. Encode or decode with the given keyword.",
            ["vigenere_start_cta"] = "Click Start to begin!",
            ["vigenere_title"] = "Vigenere Cipher",

            ["transposition_tagline"] = "Scramble text with column order.",
            ["transposition_intro"] = "A keyword defines the column order; encode or decode the text.",
            ["transposition_start_cta"] = "Click Start to begin!",
            ["transposition_title"] = "Transposition Cipher",

            ["plain_alphabet"] = "Plain Alphabet",
            ["mixed_alphabet"] = "Mixed Alphabet",

            ["mono_tagline"] = "Simple substitution with a mixed alphabet.",
            ["mono_intro"] = "Use a keyword-derived permutation of the alphabet to encode or decode the text.",
            ["mono_start_cta"] = "Click Start to begin!",
            ["mono_title"] = "Monoalphabetic Cipher",
        };

        public void SetLanguage(string lang)
        {
            if (lang != "tr" && lang != "en") lang = "en";
            if (Current == lang) return;
            Current = lang;
            OnChange?.Invoke();
        }

        public string this[string key] => Get(key);

        public string Get(string key)
        {
            var dict = Current == "tr" ? tr : en;
            return dict.TryGetValue(key, out var val) ? val : key;
        }
    }
}
