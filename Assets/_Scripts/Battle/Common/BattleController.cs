using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        public event Action<bool> OnFightOver; 
        
        private int _heroKillCount;
        
        
        private void Start()
        {
            BattleHeroAttacker.OnPlayerHit += OnPlayerHit;
            EnemyAttacker.OnEnemyHit += OnEnemyHit;
            
            BattleHero.OnHeroDead += OnHeroDead;
            Enemy.OnEnemyDead += OnEnemyDead;
        }

        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerHit -= OnPlayerHit;
            EnemyAttacker.OnEnemyHit -= OnEnemyHit;
            
            BattleHero.OnHeroDead -= OnHeroDead;
            Enemy.OnEnemyDead -= OnEnemyDead;
        }
        
        private void OnEnemyHit(BattleHero battleHero, float damage)
        {
            battleHero.GetHealth().Damage(damage);
        }

        private void OnPlayerHit(HeroData heroData)
        {
            _enemy.GetHealth().Damage(heroData._attackDamage);
        }
        
        private void OnEnemyDead(Enemy enemy)
        {
            OnFightOver?.Invoke(true);
        }

        private void OnHeroDead(BattleHero battleHero)
        {
            _heroKillCount++;

            if (_heroKillCount >= 3)
            {
                OnFightOver?.Invoke(false);
            }
        }
    }
}