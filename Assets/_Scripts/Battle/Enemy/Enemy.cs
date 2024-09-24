using System;
using _Scripts.Data.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyDataContainerSO _enemyDataContainer;
        [SerializeField] private Health _health;

        public event Action<EnemyData> OnEnemyDataSetted;
        public static event Action<Enemy> OnEnemyDead;
        
        private EnemyData m_enemyData;
        private bool m_isAlive = true;
        

        private void Start()
        {
            SetEnemyData(_enemyDataContainer.GetEnemyDataByBattleCount());
            _health.SetMaxHealth(m_enemyData._health);
            
            _health.OnDead += OnDead;
        }

        private void OnDestroy()
        {
            _health.OnDead -= OnDead;
        }

        private void OnDead()
        {
            m_isAlive = false;
            OnEnemyDead?.Invoke(this);
        }

        private void SetEnemyData(EnemyData enemyData)
        {
            m_enemyData = enemyData;
            OnEnemyDataSetted?.Invoke(enemyData);
        }

        public Health GetHealth()
        {
            return _health;
        }

        public EnemyData GetEnemyData()
        {
            return m_enemyData;
        }

        public bool GetIsAlive()
        {
            return m_isAlive;
        }
        
    }
}