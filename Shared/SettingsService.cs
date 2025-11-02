using System;

namespace PlayfairGame
{
    public enum Difficulty { Easy, Normal, Hard }

    public class SettingsService
    {
        public Difficulty Current { get; private set; } = Difficulty.Normal;
        public event Action? OnChange;

        public void SetDifficulty(Difficulty d)
        {
            if (Current == d) return;
            Current = d;
            OnChange?.Invoke();
        }
    }
}

