using System;
using _Scripts.HeroSelectionPage;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHero : MonoBehaviour
    {
        [SerializeField] private MarketHeroClickHandler _clickHandler;
        
        private HeroData m_heroData;

        public event Action<HeroData> OnHeroDataSetted;
        public event Action<BattleHero> OnBattleHeroShortPress;
        public event Action<bool> OnIsAttackHeroSetted; 


        private void Start()
        {
            _clickHandler.OnLongPressStart += OnLongPressStart;
            _clickHandler.OnLongPressEnd += OnLongPressEnd;
            _clickHandler.OnShortPress += OnShortPress;
        }

        private void OnDestroy()
        {
            _clickHandler.OnLongPressStart -= OnLongPressStart;
            _clickHandler.OnLongPressEnd -= OnLongPressEnd;
            _clickHandler.OnShortPress -= OnShortPress;
        }

        private void OnShortPress()
        {
            OnBattleHeroShortPress?.Invoke(this);
        }

        private void OnLongPressStart()
        {
            HeroInfoArea.OpenInfo(m_heroData);
        }
    
        private void OnLongPressEnd()
        {
            HeroInfoArea.CloseInfo();
        }

        public void SetHeroData(HeroData heroData)
        {
            m_heroData = heroData;
            OnHeroDataSetted?.Invoke(m_heroData);
        }

        public void SetIsAttackHero(bool isAttackHero)
        {
            OnIsAttackHeroSetted?.Invoke(isAttackHero);
        }
    }
}