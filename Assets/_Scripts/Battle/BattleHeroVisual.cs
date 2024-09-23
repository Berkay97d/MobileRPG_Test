using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHeroVisual : MonoBehaviour
    {
        [SerializeField] private BattleHero _battleHero;
        [SerializeField] private SpriteRenderer _renderer;

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
            _renderer.sprite = heroData._sprite;
        }
    }
}