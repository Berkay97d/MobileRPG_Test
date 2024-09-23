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
        }

        private void OnDestroy()
        {
            _battleHero.OnHeroDataSetted -= OnHeroDataSetted;
        }

        private void OnHeroDataSetted(HeroData heroData)
        {
            _image.sprite = heroData._sprite;
        }
    }
}