using System;
using CodeBase.Emoji;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CheckDestroyerZona : MonoBehaviour
    {
        [SerializeField] private IncreaseHealth health;
        [SerializeField] private TriggerObserver triggerObserver;

        private void OnEnable() => 
            triggerObserver.TriggerEnter += TriggerEnter2D;

        private void OnDisable() => 
            triggerObserver.TriggerEnter -= TriggerEnter2D;

        private void TriggerEnter2D(Collider2D obj)
        {
            if (obj.gameObject.CompareTag("Good"))
                health.TakeDamage();
        }
    }
}