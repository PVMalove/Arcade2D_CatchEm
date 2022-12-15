using System;

namespace CodeBase.Emoji
{
    public class GoodEmoji : Emoji
    {
        public static event Action Scoring;

        private void OnMouseDown()
        {
            Scoring?.Invoke();
            Dispose();
        }
    }
}