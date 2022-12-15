using System;

namespace CodeBase.Emoji
{
    public class BadEmoji : Emoji
    {
        public static event Action Damage;
        
        private void OnMouseDown()
        {
            Damage?.Invoke();
            Dispose();
        }
    }
}