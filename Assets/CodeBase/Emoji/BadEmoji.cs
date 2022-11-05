﻿using CodeBase.Infrastructure.Pool;
using UnityEngine;

namespace CodeBase.Emoji
{
    public class BadEmoji : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) => 
            Dispose();

        private void Dispose() => 
            ObjectPool.Despawn(gameObject, 0.1f);

        private void OnMouseDown()
        {
            Dispose();
            Debug.Log("- life");
        }
    }
}