using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHeroesController : MonoBehaviour
    {
        [SerializeField] private BattleHero[] _battleHeroes;


        private void Start()
        {
            PasteArmyHeroes();
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
    }
}