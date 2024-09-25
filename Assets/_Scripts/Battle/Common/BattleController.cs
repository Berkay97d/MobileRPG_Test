using System;
using System.Collections.Generic;
using _Scripts.Data.User;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Battle
{
    public class OnFightOverArgs : EventArgs
    {
        private bool _isWin;
        public List<BattleHero> _aliveHeroes;

        public OnFightOverArgs(bool isWin, List<BattleHero> aliveHeroes)
        {
            _isWin = isWin;
            _aliveHeroes = aliveHeroes;
        }

        public bool GetIsWin()
        {
            return _isWin;
        }
    }
    
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private BattleHero[] _battleHeroes;
        
        public static event Action<OnFightOverArgs> OnFightOver; 
        
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
            var a = heroData.GetAttackDamage(SaveSystem.GetUserData().GetExperienceById(heroData._heroID));
            Debug.Log("DAMAGE: " + a);
            _enemy.GetHealth().Damage(heroData.GetAttackDamage(SaveSystem.GetUserData().GetExperienceById(heroData._heroID)));
        }
        
        private void OnEnemyDead(Enemy enemy)
        {
            var aliveHeroes = new List<BattleHero>();

            foreach (var battleHero in _battleHeroes)
            {
                if (battleHero.GetIsAlive())
                {
                    aliveHeroes.Add(battleHero);
                }
            }
            
            OnFightOver?.Invoke(new OnFightOverArgs(true, aliveHeroes));
        }

        private void OnHeroDead(BattleHero battleHero)
        {
            _heroKillCount++;

            if (_heroKillCount >= 3)
            {
                OnFightOver?.Invoke(new OnFightOverArgs(false, null));
            }
        }
    }
}