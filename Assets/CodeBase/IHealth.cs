using System;

namespace CodeBase
{
    public interface IHealth
    {
        event Action HealthChanged;
        int Current { get; set; }
        void TakeDamage(int damage);
    }
}