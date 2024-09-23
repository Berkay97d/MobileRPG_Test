using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class Health : MonoBehaviour
    {
        private float m_maxHealth;
        private float m_currentHealth;

        public event Action OnDamaged; 

        private void Start()
        {
            m_currentHealth = m_maxHealth;
        }

        public void Damage(float damage)
        {
            m_currentHealth -= damage;
            OnDamaged?.Invoke();
        }

        public float GetMaxHealth()
        {
            return m_maxHealth;
        }

        public float GetCurrentHealth()
        {
            return m_currentHealth;
        }

        public void SetMaxHealth(float maxHealth)
        {
            m_maxHealth = maxHealth;
        }
    }
}