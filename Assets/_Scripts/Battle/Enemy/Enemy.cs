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
        [SerializeField] private Image _image;
        
        private EnemyData m_enemyData;
        

        private void Awake()
        {
            m_enemyData = _enemyDataContainer.GetEnemyDataByBattleCount();
            _health.SetMaxHealth(m_enemyData._health);
            _image.sprite = m_enemyData._sprite;
        }

        private void Start()
        {
            BattleHeroAttacker.OnPlayerAttackEnd += OnPlayerAttackEnd;
        }

        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerAttackEnd -= OnPlayerAttackEnd;
        }

        private void OnPlayerAttackEnd()
        {
            
        }

        public Health GetHealth()
        {
            return _health;
        }
        
    }
}