using System;
using _Scripts.Data.User;
using _Scripts.HeroSelectionPage;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHero : MonoBehaviour
    {
        [SerializeField] private MarketHeroClickHandler _clickHandler;
        [SerializeField] private BattleHeroAttacker _battleHeroAttacker;
        [SerializeField] private Health _health;
        
        
        private HeroData m_heroData;
        private bool m_canAttack = true;
        private bool m_isAlive = true;

        public event Action<HeroData> OnHeroDataSetted;
        public event Action<BattleHero> OnBattleHeroShortPress;
        public event Action<bool> OnIsAttackHeroSetted;
        public static event Action<BattleHero> OnHeroDead;


        private void Start()
        {
            _clickHandler.OnLongPressStart += OnLongPressStart;
            _clickHandler.OnLongPressEnd += OnLongPressEnd;
            _clickHandler.OnShortPress += OnShortPress;
            _health.OnDead += OnDead;
            BattleHeroAttacker.OnPlayerAttackStart += OnPlayerAttackStart;
            EnemyAttacker.OnEnemyAttackEnd += OnEnemyAttackEnd;
        }
        
        private void OnDestroy()
        {
            _clickHandler.OnLongPressStart -= OnLongPressStart;
            _clickHandler.OnLongPressEnd -= OnLongPressEnd;
            _clickHandler.OnShortPress -= OnShortPress;
            _health.OnDead -= OnDead;
            BattleHeroAttacker.OnPlayerAttackStart -= OnPlayerAttackStart;
            EnemyAttacker.OnEnemyAttackEnd -= OnEnemyAttackEnd;
        }

        private void OnShortPress()
        {
            if (!m_canAttack) return;
            
            OnBattleHeroShortPress?.Invoke(this);
        }

        private void OnLongPressStart()
        {
            if (!m_canAttack) return;
            
            HeroInfoArea.OpenInfo(m_heroData);
        }
    
        private void OnLongPressEnd()
        {
            HeroInfoArea.CloseInfo();
        }
        
        private void OnPlayerAttackStart()
        {
            m_canAttack = false;
        }
        
        private void OnEnemyAttackEnd()
        {
            m_canAttack = true;
        }

        private void OnDead()
        {
            m_isAlive = false;
            OnHeroDead?.Invoke(this);
        }

        public void SetHeroData(HeroData heroData)
        {
            m_heroData = heroData;
            OnHeroDataSetted?.Invoke(m_heroData);
            
            _health.SetMaxHealth(m_heroData.GetMaxHealth(SaveSystem.GetUserData().GetExperienceById(heroData._heroID)));
        }

        public HeroData GetHeroData()
        {
            return m_heroData;
        }

        public void SetIsAttackHero(bool isAttackHero)
        {
            OnIsAttackHeroSetted?.Invoke(isAttackHero);
        }

        public BattleHeroAttacker GetAttacker()
        {
            return _battleHeroAttacker;
        }

        public Health GetHealth()
        {
            return _health;
        }

        public bool GetIsAlive()
        {
            return m_isAlive;
        }
    }
}