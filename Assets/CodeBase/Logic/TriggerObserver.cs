using System;
using UnityEngine;

namespace CodeBase.Logic

{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEnter;
        private void OnTriggerEnter2D(Collider2D other) =>
            TriggerEnter?.Invoke(other);
    }
}