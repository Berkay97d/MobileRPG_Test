using System;
using _Scripts.Data.User;
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
            
            _health.text = heroData.GetMaxHealth(SaveSystem.GetUserData().GetExperienceById(heroData._heroID)).ToString();
            _attack.text = heroData.GetAttackDamage(SaveSystem.GetUserData().GetExperienceById(heroData._heroID)).ToString();
            _experience.text = SaveSystem.GetUserData().GetExperienceById(heroData._heroID).ToString();
            _level.text = ((SaveSystem.GetUserData().GetExperienceById(heroData._heroID) / 5) +1).ToString();
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