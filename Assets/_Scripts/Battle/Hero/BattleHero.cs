using System;
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

        public event Action<HeroData> OnHeroDataSetted;
        public event Action<BattleHero> OnBattleHeroShortPress;
        public event Action<bool> OnIsAttackHeroSetted; 


        private void Start()
        {
            _clickHandler.OnLongPressStart += OnLongPressStart;
            _clickHandler.OnLongPressEnd += OnLongPressEnd;
            _clickHandler.OnShortPress += OnShortPress;
            BattleHeroAttacker.OnPlayerAttackStart += OnPlayerAttackStart;
        }
        
        private void OnDestroy()
        {
            _clickHandler.OnLongPressStart -= OnLongPressStart;
            _clickHandler.OnLongPressEnd -= OnLongPressEnd;
            _clickHandler.OnShortPress -= OnShortPress;
            BattleHeroAttacker.OnPlayerAttackStart -= OnPlayerAttackStart;
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

        public void SetHeroData(HeroData heroData)
        {
            m_heroData = heroData;
            OnHeroDataSetted?.Invoke(m_heroData);
            
            _health.SetMaxHealth(m_heroData._maxHealth);
        }

        public void SetIsAttackHero(bool isAttackHero)
        {
            OnIsAttackHeroSetted?.Invoke(isAttackHero);
        }

        public BattleHeroAttacker GetAttacker()
        {
            return _battleHeroAttacker;
        }
    }
}