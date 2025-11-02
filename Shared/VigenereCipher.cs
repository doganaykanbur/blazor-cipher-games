using System;
using System.Text;

public class VigenereCipher
{
    private readonly string key; // uppercase letters only

    public VigenereCipher(string key)
    {
        if (string.IsNullOrWhiteSpace(key)) key = "KEY";
        var sb = new StringBuilder();
        foreach (var ch in key.ToUpper())
            if (ch >= 'A' && ch <= 'Z') sb.Append(ch);
        this.key = sb.Length > 0 ? sb.ToString() : "KEY";
    }

    public string Encode(string plaintext)
    {
        return Transform(plaintext, encode: true);
    }

    public string Decode(string ciphertext)
    {
        return Transform(ciphertext, encode: false);
    }

    private string Transform(string input, bool encode)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var sb = new StringBuilder(input.Length);
        int ki = 0;
        foreach (var raw in input.ToUpper())
        {
            char ch = raw;
            if (ch >= 'A' && ch <= 'Z')
            {
                int p = ch - 'A';
                int k = key[ki % key.Length] - 'A';
                int c = encode ? (p + k) % 26 : (p - k + 26) % 26;
                sb.Append((char)('A' + c));
                ki++;
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}

