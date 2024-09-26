using System;
using _Scripts.Battle;
using _Scripts.Data.Enemy;
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
            
            _health.text = heroData.GetMaxHealth().ToString();
            _attack.text = heroData.GetAttackDamage().ToString();
            _experience.text = SaveSystem.GetUserData().GetExperienceById(heroData._heroID).ToString();
            _level.text = ((SaveSystem.GetUserData().GetExperienceById(heroData._heroID) / 5) +1).ToString();
        }

        private void AdjustVisual(Enemy enemy)
        {
            var enemyData = enemy.GetEnemyData();
            
            _heroImage.sprite = enemyData._sprite;
            _health.text = enemy.GetHealth().GetCurrentHealth().ToString();
            _attack.text = enemyData._attack.ToString();

            _name.text = "-";
            _experience.text = "-";
            _level.text = "-";
        }

        private void AdjustVisual(BattleHero battleHero)
        {
            var heroData = battleHero.GetHeroData();
            
            _heroImage.sprite = heroData._sprite;
            _name.text = heroData._name;

            _health.text = battleHero.GetHealth().GetCurrentHealth().ToString();
            _attack.text = heroData.GetAttackDamage().ToString();
            _experience.text = SaveSystem.GetUserData().GetExperienceById(heroData._heroID).ToString();
            _level.text = ((SaveSystem.GetUserData().GetExperienceById(heroData._heroID) / 5) +1).ToString();
        }
        
        public static void OpenInfoMenu(HeroData heroData)
        {
            MS_INSTANCE.AdjustVisual(heroData);
            MS_INSTANCE.SetActive(true);
        }
        
        public static void OpenInfoBattle(BattleHero battleHero)
        {
            if (BattleHeroAttacker.ms_isHeroAttacking || EnemyAttacker.ms_isEnemyAttacking)
            {
                return;
            }
            
            MS_INSTANCE.AdjustVisual(battleHero);
            MS_INSTANCE.SetActive(true);
        }
        
        public static void OpenInfoBattle(Enemy enemy)
        {
            MS_INSTANCE.AdjustVisual(enemy);
            MS_INSTANCE.SetActive(true);
        }

        public static void CloseInfo()
        {
            MS_INSTANCE.SetActive(false);
        }
    }
}