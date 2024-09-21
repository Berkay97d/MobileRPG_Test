using System;
using _Scripts.HeroSelectionPage;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarketHero : MonoBehaviour
{
    [SerializeField] private Transform _mainTransform;
    [SerializeField] private MarketHeroClickHandler _marketHeroClickHandler;
    
    public event Action<HeroData> OnHeroDataSetted;
    
    private HeroData m_heroData;

    private void Start()
    {
        _marketHeroClickHandler.OnLongPressStart += OnLongPressStart;
        _marketHeroClickHandler.OnLongPressEnd += OnLongPressEnd;
        _marketHeroClickHandler.OnShortPress += OnShortPress;
    }

    private void OnDestroy()
    {
        _marketHeroClickHandler.OnLongPressStart -= OnLongPressStart;
        _marketHeroClickHandler.OnLongPressEnd -= OnLongPressEnd;
        _marketHeroClickHandler.OnShortPress -= OnShortPress;
    }

    private void OnShortPress()
    {
        if (!_mainTransform.gameObject.activeSelf) return;
        
    }

    private void OnLongPressEnd()
    {
        if (!_mainTransform.gameObject.activeSelf) return;
        
    }

    private void OnLongPressStart()
    {
        if (!_mainTransform.gameObject.activeSelf) return;
        
    }


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
