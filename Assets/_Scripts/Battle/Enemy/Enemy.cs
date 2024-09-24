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
        
        private EnemyData m_enemyData;
        

        private void Start()
        {
            SetEnemyData(_enemyDataContainer.GetEnemyDataByBattleCount());
            
            _health.SetMaxHealth(m_enemyData._health);
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
        
    }
}