using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class HeroInfoArea : MonoBehaviour
    {
        [SerializeField] private Transform _mainTransform;
        [SerializeField] private Image _heroImage;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _attack;
        [SerializeField] private TMP_Text _experience;
        [SerializeField] private TMP_Text _level;
        
        
        private static HeroInfoArea MS_INSTANCE;
        


        private void Awake()
        {
            MS_INSTANCE = this;
        }

        private void SetActive(bool isActive)
        {
            _mainTransform.gameObject.SetActive(isActive);
        }

        private void AdjustVisual(HeroData heroData)
        {
            _heroImage.sprite = heroData._sprite;
            _name.text = heroData._name;
            _health.text = heroData._maxHealth.ToString();
            _attack.text = heroData._attackDamage.ToString();
            _experience.text = heroData._experience.ToString();
            _level.text = heroData._level.ToString();
        }

        public static void OpenInfo(HeroData heroData)
        {
            MS_INSTANCE.AdjustVisual(heroData);
            MS_INSTANCE.SetActive(true);
        }

        public static void CloseInfo()
        {
            MS_INSTANCE.SetActive(false);
        }
    }
}