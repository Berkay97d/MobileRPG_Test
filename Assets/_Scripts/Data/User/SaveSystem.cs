﻿using System;
using System.IO;
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
            m_userData = LoadData();
            MS_INSTANCE = this;
        }
        
        private void SaveData(UserData data)
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json); // Write JSON data to the file
        }

        // Load the saved battleCount from the JSON file
        private UserData LoadData()
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                UserData data = JsonUtility.FromJson<UserData>(json);
                return data;
            }

            var userData = new UserData();
            AddDefaultHeroes(userData);
            
            return new UserData(); // Return new SaveData with default values if no file exists
            
        }

        private void AddDefaultHeroes(UserData userData)
        {
            Debug.Log("VAR");
            foreach (var defaultOwnedHeroId in _defaultOwnedHeroIds)
            {
                userData.AddHeroToUser(defaultOwnedHeroId);
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