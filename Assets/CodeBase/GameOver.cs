using System;
using CodeBase.Infrastructure.Pool;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private IncreaseHealth _health;
       
        public static event Action GameLost;

        private void OnEnable()
        {
            _health.HealthChanged += HealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (_health.Current <= 0)
            {
                Debug.Log("GameOver");
                GameLost?.Invoke();
            }
        }
    }
}