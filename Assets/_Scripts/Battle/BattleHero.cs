using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleHero : MonoBehaviour
    {
        private HeroData m_heroData;

        public event Action<HeroData> OnHeroDataSetted;
        
        public void SetHeroData(HeroData heroData)
        {
            m_heroData = heroData;
            OnHeroDataSetted?.Invoke(m_heroData);
        }
    }
}