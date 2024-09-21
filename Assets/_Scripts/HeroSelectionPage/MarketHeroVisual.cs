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
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _attack;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _experience;
    

    private void Start()
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
        _name.text = heroData._name;
        _health.text = heroData._maxHealth.ToString();
        _attack.text = heroData._attackDamage.ToString();
        _level.text = heroData._level.ToString();
        _experience.text = heroData._experience.ToString();
    }
}
