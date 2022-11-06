using System;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(ActorUI))]
    public class IncreaseHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private ActorUI _actorUI;
        
        [SerializeField, Range(0, 5)] private int _currentHealth;

        public event Action HealthChanged;

        public int Current
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

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