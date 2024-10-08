﻿using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHeroAttacker : MonoBehaviour
    {
        [SerializeField] private BattleHero _battleHero;
        [SerializeField] private RectTransform _attackPosition;
        [SerializeField] private RectTransform _enemyPosition;
        [SerializeField] private float _attackPositionMoveTime;
        [SerializeField] private float _waitBeforeAttackTime;
        [SerializeField] private float _waitAfterAttackTime;
        
        
        public static event Action OnPlayerAttackStart;
        public static event Action<HeroData> OnPlayerHit; 
        public static event Action OnPlayerAttackEnd;
        public static bool ms_isHeroAttacking;
        
        private RectTransform m_startTransform;
        private HeroData m_heroData;
        


        private void Awake()
        {
            _battleHero.OnHeroDataSetted += OnHeroDataSetted;
        }

        private void OnDestroy()
        {
            _battleHero.OnHeroDataSetted -= OnHeroDataSetted;
        }

        private void OnHeroDataSetted(HeroData heroData)
        {
            SetHeroData(heroData);
        }

        public void StartAttack()
        {
            OnPlayerAttackStart?.Invoke();
            StartCoroutine(AttackRoutine());
            
            IEnumerator AttackRoutine()
            {
                ms_isHeroAttacking = true;
                var startPos = transform.position;
                
                transform.DOMove(_attackPosition.position, _attackPositionMoveTime);

                yield return new WaitForSeconds(_attackPositionMoveTime + _waitBeforeAttackTime);
                
                transform.DOMove(_enemyPosition.position, 0.3f)
                    .SetEase(Ease.InBack)
                    .OnComplete(() =>
                    {
                        OnPlayerHit?.Invoke(m_heroData);
                    });
                
                yield return new WaitForSeconds(0.3f);
                
                transform.DOMove(_attackPosition.position, 0.5f)
                    .SetEase(Ease.Flash);
                
                yield return new WaitForSeconds(_waitAfterAttackTime);


                transform.DOMove(startPos, _attackPositionMoveTime)
                    .OnComplete(() =>
                    {
                        OnPlayerAttackEnd?.Invoke();
                        ms_isHeroAttacking = false;
                    });

            }
            
        }

        private void SetHeroData(HeroData heroData)
        {
            m_heroData = heroData;
        }

        
    }
}