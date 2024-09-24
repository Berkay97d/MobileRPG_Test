using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class BattleHeroVisual : MonoBehaviour
    {
        [SerializeField] private BattleHero _battleHero;
        [SerializeField] private Image _heroImage;
        

        private void Awake()
        {
            _battleHero.OnHeroDataSetted += OnHeroDataSetted;
            _battleHero.OnIsAttackHeroSetted += OnIsAttackHeroSetted;
            BattleHero.OnHeroDead += OnHeroDead;
            BattleHeroAttacker.OnPlayerAttackStart += OnPlayerAttackStart;
        }
        
        private void OnDestroy()
        {
            _battleHero.OnHeroDataSetted -= OnHeroDataSetted;
            _battleHero.OnIsAttackHeroSetted -= OnIsAttackHeroSetted;
            BattleHero.OnHeroDead -= OnHeroDead;
            BattleHeroAttacker.OnPlayerAttackStart -= OnPlayerAttackStart;
        }

        private void OnHeroDataSetted(HeroData heroData)
        {
            _heroImage.sprite = heroData._sprite;
        }
        
        private void OnIsAttackHeroSetted(bool isAttackHero)
        {
            if (isAttackHero)
            {
                SetHeroImageColor(Color.green);
                return;
            }
            
            SetHeroImageColor(Color.white);
        }
        
        private void OnHeroDead(BattleHero battleHero)
        {
            if (_battleHero == battleHero)
            {
                SetHeroImageColor(Color.red);
            }
        }
        
        private void OnPlayerAttackStart()
        {
            SetHeroImageColor(Color.white);
        }

        private void SetHeroImageColor(Color color)
        {
            if (color == Color.red)
            {
                _heroImage.color = color;    
                return;
            }
            
            if (!_battleHero.GetIsAlive()) return;
            
            _heroImage.color = color;
        }
    }
}