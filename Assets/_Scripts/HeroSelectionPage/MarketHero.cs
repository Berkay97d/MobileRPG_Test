using System;
using _Scripts;
using _Scripts.HeroSelectionPage;
using UnityEngine;


public class MarketHero : MonoBehaviour
{
    [SerializeField] private Transform _mainTransform;
    [SerializeField] private MarketHeroClickHandler _marketHeroClickHandler;
    
    public event Action OnHeroDataSetted;
    public event Action<ArmyActionResult> OnHeroArmyStateChange;
    
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
        var actionResult = Army.DoAddRemoveArmyActions(m_heroData);
        OnHeroArmyStateChange?.Invoke(actionResult);
    }

    private void OnLongPressStart()
    {
        if (!_mainTransform.gameObject.activeSelf) return;
        HeroInfoArea.OpenInfoMenu(m_heroData);
    }
    
    private void OnLongPressEnd()
    {
        if (!_mainTransform.gameObject.activeSelf) return;
        HeroInfoArea.CloseInfo();
    }

    public void SetActiveMarketHero(bool isActive)
    {
        _mainTransform.gameObject.SetActive(isActive);
    }

    public void SetHeroData(HeroData heroData)
    {
        m_heroData = heroData;
        
        OnHeroDataSetted?.Invoke();
    }

    public HeroData GetHeroData()
    {
        return m_heroData;
    }
    
}
