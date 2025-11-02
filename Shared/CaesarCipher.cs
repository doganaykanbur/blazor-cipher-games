using System;
using System.Linq;
using System.Text;

public class CaesarCipher
{
    private readonly int shift; // 1-25

    public CaesarCipher(int shift)
    {
        if (shift % 26 == 0) shift = 3; // avoid no-op
        this.shift = ((shift % 26) + 26) % 26;
    }

    public string Encode(string plaintext)
    {
        return Transform(plaintext, shift);
    }

    public string Decode(string ciphertext)
    {
        return Transform(ciphertext, 26 - shift);
    }

    private static string Transform(string input, int s)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var sb = new StringBuilder(input.Length);
        foreach (var ch in input.ToUpper())
        {
            if (ch >= 'A' && ch <= 'Z')
            {
                int idx = ch - 'A';
                int nidx = (idx + s) % 26;
                sb.Append((char)('A' + nidx));
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}

