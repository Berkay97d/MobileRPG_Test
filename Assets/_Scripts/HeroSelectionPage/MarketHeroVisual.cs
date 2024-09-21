using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketHeroVisual : MonoBehaviour
{
    [SerializeField] private MarketHero m_marketHero;
    [SerializeField] private Image _heroImage;
   
    

    private void Awake()
    {
        m_marketHero.OnHeroDataSetted += OnHeroDataSetted;
    }

    private void OnDestroy()
    {
        m_marketHero.OnHeroDataSetted -= OnHeroDataSetted;
    }

    private void OnHeroDataSetted(HeroData heroData)
    {
        AdjustVisuals(heroData);
    }

    private void AdjustVisuals(HeroData heroData)
    {
        _heroImage.sprite = heroData._sprite;
    }
}
