using System;
using System.IO;
using TMPro;
using UnityEngine;

namespace _Scripts.Data.User
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private int[] _defaultOwnedHeroIds;
        [SerializeField] private TMP_Text m_type;
        
        
        private UserData m_userData;
        
        
        private void Awake()
        {
            m_userData = LoadData();
            AddDefaultHeroes();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnityEngine.Debug.Log("space");
                UnityEngine.Debug.Log(m_userData.GetBattleCount());
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                UnityEngine.Debug.Log("enter");

                foreach (var VARIABLE in m_userData.GetOwnedHeroIds())
                {
                    Debug.Log(VARIABLE);
                }
            }
        }

        private void SaveData()
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            string json = JsonUtility.ToJson(m_userData);
            File.WriteAllText(path, json); 
        }
        
        private UserData LoadData()
        {
            string path = Application.dataPath + "/Resources/Data/savefile.json";
            
            if (File.Exists(path))
            {
                Debug.Log("YÜKLEDİM");
                string json = File.ReadAllText(path);
                UserData data = JsonUtility.FromJson<UserData>(json);
                return data;
            }

            Debug.Log("YENİ OLUŞTURDUM");
            var userData = new UserData();
            return userData;
        }

        private void AddDefaultHeroes()
        {
            foreach (var defaultOwnedHeroId in _defaultOwnedHeroIds)
            {
                AddHeroToUserData(defaultOwnedHeroId);
            }
            
            SaveData();
        }
        
        private void AddHeroToUserData(int heroId)
        {
            m_userData.AddHeroToUser(heroId);
            
            SaveData();
        }
    }
}