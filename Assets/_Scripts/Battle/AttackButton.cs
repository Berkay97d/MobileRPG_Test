using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class AttackButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        
        private void Start()
        {
            _button.interactable = false;
            BattleHeroesController.OnBattleHeroChange += OnBattleHeroChange;
        }

        private void OnDestroy()
        {
            BattleHeroesController.OnBattleHeroChange -= OnBattleHeroChange;
        }

        private void OnBattleHeroChange(BattleHero battleHero)
        {
            if (!battleHero)
            {
                _button.interactable = false;
                return;
            }
            
            _button.interactable = true;
        }
    }
}