using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TranspositionCipher
{
    private readonly string keyword; // uppercase letters only
    private readonly int[] perm;     // column order (indices of columns in sorted keyword order)

    public TranspositionCipher(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) keyword = "KEY";
        this.keyword = new string(keyword.ToUpper().Where(ch => ch >= 'A' && ch <= 'Z').ToArray());
        if (this.keyword.Length == 0) this.keyword = "KEY";
        perm = BuildPermutation(this.keyword);
    }

    // Build a stable ordering of column indices by sorting keyword letters (A-Z),
    // ties broken by original index.
    private static int[] BuildPermutation(string key)
    {
        return Enumerable.Range(0, key.Length)
            .OrderBy(i => key[i])
            .ThenBy(i => i)
            .ToArray();
    }

    public string Encode(string plaintext)
    {
        var text = new string(plaintext.ToUpper().Where(ch => ch >= 'A' && ch <= 'Z').ToArray());
        if (text.Length == 0) return string.Empty;

        int cols = keyword.Length;
        int rows = (int)Math.Ceiling(text.Length / (double)cols);
        int paddedLen = rows * cols;
        var padded = text.PadRight(paddedLen, 'X');

        // Fill matrix row-wise
        char[,] grid = new char[rows, cols];
        for (int i = 0; i < paddedLen; i++)
            grid[i / cols, i % cols] = padded[i];

        // Read columns in perm order
        var sb = new StringBuilder(paddedLen);
        foreach (var c in perm)
            for (int r = 0; r < rows; r++)
                sb.Append(grid[r, c]);

        return sb.ToString();
    }

    public string Decode(string ciphertext)
    {
        var text = new string(ciphertext.ToUpper().Where(ch => ch >= 'A' && ch <= 'Z').ToArray());
        if (text.Length == 0) return string.Empty;

        int cols = keyword.Length;
        int rows = (int)Math.Ceiling(text.Length / (double)cols);
        int total = rows * cols;
        var padded = text.PadRight(total, 'X');

        // column lengths are uniform due to padding
        char[,] grid = new char[rows, cols];

        int idx = 0;
        foreach (var c in perm)
        {
            for (int r = 0; r < rows; r++)
            {
                grid[r, c] = padded[idx++];
            }
        }

        // read row-wise
        var sb = new StringBuilder(total);
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                sb.Append(grid[r, c]);

        // trim padding X that were added at end
        return sb.ToString().TrimEnd('X');
    }
}

