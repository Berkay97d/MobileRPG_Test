using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class BattleHeroVisual : MonoBehaviour
    {
        [SerializeField] private BattleHero _battleHero;
        [SerializeField] private Image _image;

        private void Awake()
        {
            _battleHero.OnHeroDataSetted += OnHeroDataSetted;
            _battleHero.OnIsAttackHeroSetted += OnIsAttackHeroSetted;
            BattleHeroAttacker.OnPlayerAttackStart += OnPlayerAttackStart;
        }
        
        private void OnDestroy()
        {
            _battleHero.OnHeroDataSetted -= OnHeroDataSetted;
            _battleHero.OnIsAttackHeroSetted -= OnIsAttackHeroSetted;
            BattleHeroAttacker.OnPlayerAttackStart -= OnPlayerAttackStart;
        }

        private void OnHeroDataSetted(HeroData heroData)
        {
            _image.sprite = heroData._sprite;
        }
        
        private void OnIsAttackHeroSetted(bool isAttackHero)
        {
            if (isAttackHero)
            {
                _image.color = Color.green;
                return;
            }
            
            _image.color = Color.white;
        }
        
        private void OnPlayerAttackStart()
        {
            _image.color = Color.white;
        }
    }
}