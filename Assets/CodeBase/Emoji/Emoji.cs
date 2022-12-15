using CodeBase.Infrastructure.Pool;
using UnityEngine;

namespace CodeBase.Emoji
{
    public abstract class Emoji : MonoBehaviour
    { 
        public void OnTriggerEnter2D(Collider2D col) =>
            Dispose();
        public void Dispose() =>
            ObjectPool.Despawn(gameObject, 0.1f);
    }
}