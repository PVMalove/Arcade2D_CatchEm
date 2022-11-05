using System;
using CodeBase.Infrastructure.Pool;
using UnityEngine;

namespace CodeBase.Emoji
{
    public class BadEmoji : MonoBehaviour
    {
        public event Action OnClick;
        
        private void OnTriggerEnter2D(Collider2D col) =>
            Dispose();

        private void OnMouseDown()
        {
            Dispose();
            OnClick?.Invoke();
        }

        private void Dispose() =>
            ObjectPool.Despawn(gameObject, 0.1f);
    }
}