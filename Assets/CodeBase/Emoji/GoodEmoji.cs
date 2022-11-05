using System;
using CodeBase.Infrastructure.Pool;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Emoji
{
    public class GoodEmoji : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) => 
            Dispose();

        private void OnMouseDown()
        {
            Dispose();
        }

        private void Dispose() =>
            ObjectPool.Despawn(gameObject,0.1f);
    }
}