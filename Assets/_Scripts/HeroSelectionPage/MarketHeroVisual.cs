using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketHeroVisual : MonoBehaviour
{
    [SerializeField] private MarketHero m_marketHero;
    [SerializeField] private Image _heroImage;
    [SerializeField] private Image _bgImage;
    
    private static Color MS_ARMY_HERO_COLOR = Color.green;
    private static Color MS_NONARMY_HERO_COLOR = Color.white;
    

    private void Awake()
    {
        m_marketHero.OnHeroDataSetted += OnHeroDataSetted;
        m_marketHero.OnHeroArmyStateChange += OnHeroArmyStateChange;
    }
    
    private void OnDestroy()
    {
        m_marketHero.OnHeroDataSetted -= OnHeroDataSetted;
        m_marketHero.OnHeroArmyStateChange -= OnHeroArmyStateChange;
    }

    private void OnHeroDataSetted()
    {
        AdjustVisuals(m_marketHero.GetHeroData());
    }

    private void AdjustVisuals(HeroData heroData)
    {
        _heroImage.sprite = heroData._sprite;
    }
    
    private void OnHeroArmyStateChange(ArmyActionResult armyActionResult)
    {
        switch (armyActionResult)
        {
            case ArmyActionResult.ADDED:
                _bgImage.color = MS_ARMY_HERO_COLOR;
                break;
            case ArmyActionResult.REMOVE:
                _bgImage.color = MS_NONARMY_HERO_COLOR;
                break;
        }
    }
}
