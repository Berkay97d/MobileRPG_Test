using System;
using System.Collections.Generic;
using System.IO;
using _Scripts.Battle;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Data.User
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private int[] _defaultOwnedHeroIds;
        [SerializeField] private HeroDataContainerSO _heroDataContainerSo;
        [SerializeField] private int _toGainHeroBattleCount;
        
        private static SaveSystem MS_INSTANCE;
        private UserData m_userData;
        private bool m_isNewData ;
        
        
        private void Awake()
        {
            MS_INSTANCE = this;
            m_userData = LoadData();

            if (m_isNewData)
            {
                AddDefaultHeroes(m_userData);   
            }
        }

        private void Start()
        {
            BattleController.OnFightOver += OnFightOver;
        }

        private void OnDestroy()
        {
            BattleController.OnFightOver -= OnFightOver;
        }

        private void OnFightOver(OnFightOverArgs eventArgs)
        {
            if (!eventArgs.GetIsWin()) return;

            BoostHeroExperience(eventArgs._aliveHeroes);
            m_userData.IncreaseBattleCount();
            GiveNewHero();
            SaveData(m_userData);
        }
        
        private void SaveData(UserData data)
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            //string path = Application.persistentDataPath + "/savefile.json"; //TODO CHANGE PATHS FOR MOBILE BUILD
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json); 
        }
        
        private UserData LoadData()
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            //string path = Application.persistentDataPath + "/savefile.json"; //TODO CHANGE PATHS FOR MOBILE BUILD
            if (File.Exists(path))
            {
                m_isNewData = false;
                string json = File.ReadAllText(path);
                UserData data = JsonUtility.FromJson<UserData>(json);
                return data;
            }

            m_isNewData = true;
           
            return new UserData();
        }
        
        private void BoostHeroExperience(List<BattleHero> battleHeroes)
        {
            foreach (var battleHero in battleHeroes)
            {
                m_userData.IncreaseExperienceById(battleHero.GetHeroData()._heroID);
            }
        }

        private void GiveNewHero()
        {
            if (m_userData._battleCount % _toGainHeroBattleCount == 0)
            {
                var heroData = GetUnequipRandomHero();
                AddHeroToUserData(heroData._heroID);
            }
        }

        private void AddDefaultHeroes(UserData userData)
        {
            foreach (var defaultOwnedHeroId in _defaultOwnedHeroIds)
            {
                userData.AddHeroToUser(defaultOwnedHeroId);
            }
            
            SaveData(m_userData);
        }
        
        private void AddHeroToUserData(int heroId)
        {
            m_userData.AddHeroToUser(heroId);
            
            SaveData(m_userData);
        }

        private HeroData GetUnequipRandomHero()
        {
            var allHeroDatas = _heroDataContainerSo.GetAllHeroDatas();
            var randomHeroData = allHeroDatas[Random.Range(0, allHeroDatas.Length)];

            if (m_userData._ownedHeroIds.Contains(randomHeroData._heroID))
            {
                return GetUnequipRandomHero();
            }

            return randomHeroData;
        }

        public static UserData GetUserData()
        {
            return MS_INSTANCE.m_userData;
        }
    }
}