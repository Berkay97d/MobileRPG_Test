﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Battle
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private List<BattleHero> _battleHeroes;
        [SerializeField] private Enemy _enemy;
        
        [SerializeField] private float _attackPositionGap;
        [SerializeField] private float _attackPositionMoveTime;
        [SerializeField] private float _waitBeforeAttackTime;
        [SerializeField] private float _waitAfterAttackTime;

        public static event Action<BattleHero, float> OnEnemyHit;
        public static event Action OnEnemyAttackEnd;
        public static bool ms_isEnemyAttacking;
        
        private void Start()
        {
            BattleHeroAttacker.OnPlayerAttackEnd += OnPlayerAttackEnd;
            BattleHero.OnHeroDead += OnBattleHeroDead;
        }
        
        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerAttackEnd -= OnPlayerAttackEnd;
            BattleHero.OnHeroDead -= OnBattleHeroDead;
        }
        
        private void OnBattleHeroDead(BattleHero battleHero)
        {
            _battleHeroes.Remove(battleHero);
        }

        private void OnPlayerAttackEnd()
        {
            if (!_enemy.GetIsAlive()) return;
            
            StartAttack();   
        }

        private void StartAttack()
        {
            var target = GetRandomBattleHero();
            StartCoroutine(AttackRoutine());
            
            IEnumerator AttackRoutine()
            {
                ms_isEnemyAttacking = true;
                var startPos = transform.position;

                var _attackPosition = new Vector3(target.transform.position.x + _attackPositionGap,
                    target.transform.position.y, target.transform.position.z);
                transform.DOMove(_attackPosition, _attackPositionMoveTime);

                yield return new WaitForSeconds(_attackPositionMoveTime + _waitBeforeAttackTime);
                
                transform.DOMove(target.transform.position, 0.3f)
                    .SetEase(Ease.InBack)
                    .OnComplete(() =>
                    {
                        OnEnemyHit?.Invoke(target, _enemy.GetEnemyData()._attack);
                    });
                
                yield return new WaitForSeconds(0.3f);
                
                transform.DOMove(_attackPosition, 0.5f)
                    .SetEase(Ease.Flash);
                
                yield return new WaitForSeconds(_waitAfterAttackTime);


                transform.DOMove(startPos, _attackPositionMoveTime)
                    .OnComplete(() =>
                    {
                        OnEnemyAttackEnd?.Invoke();
                        ms_isEnemyAttacking = false;
                    });
            }
        }

        private BattleHero GetRandomBattleHero()
        {
            return _battleHeroes[Random.Range(0, _battleHeroes.Count - 1)];
        }
    }
}