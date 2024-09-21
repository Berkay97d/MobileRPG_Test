using System;
using _Scripts.Data.User;
using UnityEngine;

namespace _Scripts.HeroSelectionPage
{
    public class MarketHeroAreaController : MonoBehaviour
    {
        [SerializeField] private HeroDataContainerSO _heroDataContainer;
        [SerializeField] private MarketHero[] _marketHeroes;


        private void Start()
        {
            OpenMarketHeroes();
        }

        private void OpenMarketHeroes()
        {
            var heroIds = SaveSystem.GetUserData()._ownedHeroIds;

            for (int i = 0; i < heroIds.Count; i++)
            {
                _marketHeroes[i].SetHeroData(_heroDataContainer.GetHeroDataById(heroIds[i]));
            }

            for (int i = heroIds.Count; i < _marketHeroes.Length; i++)
            {
                _marketHeroes[i].SetActiveMarketHero(false);
            }
        }
        
        
    }
}