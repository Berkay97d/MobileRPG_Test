using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;


        private void Start()
        {
            BattleHeroAttacker.OnPlayerHit += OnPlayerHit;
        }

        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerHit -= OnPlayerHit;
        }

        private void OnPlayerHit(HeroData heroData)
        {
            _enemy.GetHealth().Damage(heroData._attackDamage);
        }
    }
}