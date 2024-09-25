﻿using System;
using System.Collections.Generic;
using System.IO;
using _Scripts.Battle;
using TMPro;
using UnityEngine;

namespace _Scripts.Data.User
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private int[] _defaultOwnedHeroIds;

        private static SaveSystem MS_INSTANCE;
        private UserData m_userData;
        
        
        private void Awake()
        {
            MS_INSTANCE = this;
            m_userData = LoadData();
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

            foreach (var battleHero in eventArgs._aliveHeroes)
            {
                Debug.Log("ALİVE HERO");
                m_userData.IncreaseExperienceById(battleHero.GetHeroData()._heroID);
            }
            
            m_userData.IncreaseBattleCount();
            
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
                Debug.Log("VAR OLAN DATA GETİRİLDİ");
                string json = File.ReadAllText(path);
                UserData data = JsonUtility.FromJson<UserData>(json);
                return data;
            }

            var userData = new UserData();
            AddDefaultHeroes(userData);
            Debug.Log("YENİ DATA OLUŞTURULUP GÖNDERİLDİ");
            return userData;

        }

        private void AddDefaultHeroes(UserData userData)
        {
            Debug.Log("VAR");
            foreach (var defaultOwnedHeroId in _defaultOwnedHeroIds)
            {
                userData.AddHeroToUser(defaultOwnedHeroId);
                userData._idToExperience.Add(0);
            }
            
            SaveData(userData);
        }
        
        private void AddHeroToUserData(int heroId)
        {
            m_userData.AddHeroToUser(heroId);
            
            SaveData(m_userData);
        }

        public static UserData GetUserData()
        {
            return MS_INSTANCE.m_userData;
        }
    }
}