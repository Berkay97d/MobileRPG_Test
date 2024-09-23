using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class AttackButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private BattleHeroesController _battleHeroesController;
        
        
        private void Start()
        {
            _button.interactable = false;
            _button.onClick.AddListener(StartAttackPattern);
            BattleHeroesController.OnBattleHeroChange += OnBattleHeroChange;
            BattleHeroAttacker.OnPlayerAttackStart += OnPlayerAttackStart;
        }
        
        private void OnDestroy()
        {
            BattleHeroesController.OnBattleHeroChange -= OnBattleHeroChange;
            BattleHeroAttacker.OnPlayerAttackStart -= OnPlayerAttackStart;
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

        private void OnPlayerAttackStart()
        {
            _button.interactable = false;
        }
        
        private void StartAttackPattern()
        {
            _battleHeroesController.GetSelectedBattleHero().GetAttacker().StartAttack();
        }
    }
}