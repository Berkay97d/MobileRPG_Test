using System;
using UnityEngine;

public class MarketHero : MonoBehaviour
{
    [SerializeField] private Transform _mainTransform;

    public event Action<HeroData> OnHeroDataSetted;
    
    private HeroData m_heroData;
    
    
    public void SetActiveMarketHero(bool isActive)
    {
        _mainTransform.gameObject.SetActive(isActive);
    }

    public void SetHeroData(HeroData heroData)
    {
        m_heroData = heroData;
        
        OnHeroDataSetted?.Invoke(m_heroData);
    }
    
    
}
