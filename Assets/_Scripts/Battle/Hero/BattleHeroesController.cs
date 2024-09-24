using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHeroesController : MonoBehaviour
    {
        [SerializeField] private BattleHero[] _battleHeroes;

        public static event Action<BattleHero> OnBattleHeroChange; 
        
        private BattleHero m_selectedBattleHero;
        

        private void Start()
        {
            PasteArmyHeroes();

            foreach (var battleHero in _battleHeroes)
            {
                battleHero.OnBattleHeroShortPress += OnBattleHeroShortPress;
            }
        }

        private void OnDestroy()
        {
            foreach (var battleHero in _battleHeroes)
            {
                battleHero.OnBattleHeroShortPress -= OnBattleHeroShortPress;
            }
        }

        private void OnBattleHeroShortPress(BattleHero battleHero)
        {
            if (!battleHero.GetIsAlive()) return;
            
            if (m_selectedBattleHero == battleHero)
            {
                battleHero.SetIsAttackHero(false);
                SetSelectedHero(null);
                return;
            }

            if (m_selectedBattleHero != null)
            {
                m_selectedBattleHero.SetIsAttackHero(false);
                battleHero.SetIsAttackHero(true);
                SetSelectedHero(battleHero);
                return;
            }
            
            battleHero.SetIsAttackHero(true);
            SetSelectedHero(battleHero);
        }

        private void PasteArmyHeroes()
        {
            var heroDatas = Army.GetAllHeroDatas();
            foreach (var VAR in heroDatas)
            {
                Debug.Log(VAR._name);
            }
            
            for (var i = 0; i < heroDatas.Count; i++)
            {
                _battleHeroes[i].SetHeroData(heroDatas[i]);
            }
        }

        private void SetSelectedHero(BattleHero battleHero)
        {
            m_selectedBattleHero = battleHero;
            OnBattleHeroChange?.Invoke(battleHero);
        }

        public BattleHero GetSelectedBattleHero()
        {
            return m_selectedBattleHero;
        }
        
        
    }
}