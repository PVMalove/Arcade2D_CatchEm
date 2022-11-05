using System;
using CodeBase.Emoji;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CheckDestroyerZona : MonoBehaviour
    {
        [SerializeField] private IncreaseHealth health;
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private BadEmoji badEmoji;

        [SerializeField] private int _damage = 1;

        private void Start()
        {
            badEmoji.OnClick += Damage;
        }

        private void OnEnable()
        {
            triggerObserver.TriggerEnter += TriggerEnter2D;
            
        }

        private void Damage()
        {
            health.TakeDamage(_damage);
        }

        private void OnDisable() => 
            triggerObserver.TriggerEnter -= TriggerEnter2D;

        private void TriggerEnter2D(Collider2D obj)
        {
            if (obj.gameObject.CompareTag("Good"))
                health.TakeDamage(_damage);
        }
    }
}