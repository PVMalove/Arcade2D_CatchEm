using System;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Logic
{
    public class IncreaseHealth : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private int _currentHealth;

        public event Action HealthChanged;

        public int Current
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        private ActorUI _actorUI;

        private void Start() =>
            _actorUI = GetComponent<ActorUI>();

        public void TakeDamage(int damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            _actorUI.AnimateBar();
            HealthChanged?.Invoke();
        }
    }
}