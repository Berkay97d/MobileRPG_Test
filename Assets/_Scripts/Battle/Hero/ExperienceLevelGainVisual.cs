using System;
using System.Collections;
using _Scripts.Data.User;
using TMPro;
using UnityEngine;

namespace _Scripts.Battle
{
    public class ExperienceLevelGainVisual : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private BattleHero _battleHero;
        

        private void Start()
        {
            BattleController.OnFightOver += OnFightOver;
        }

        private void OnDestroy()
        {
            BattleController.OnFightOver -= OnFightOver;
        }

        private void OnFightOver(OnFightOverArgs onFightOverArgs)
        {
            if (!onFightOverArgs.GetIsWin()) return;
            if (!_battleHero.GetIsAlive()) return;

            ShowExperienceRoutine();
        }

        private void ShowExperienceRoutine()
        {
            StartCoroutine(ShowGainRoutine());
            
            IEnumerator ShowGainRoutine()
            {
                yield return new WaitForSeconds(3f);
                var exp = SaveSystem.GetUserData().GetExperienceById(_battleHero.GetHeroData()._heroID);

                if (exp % 5  == 0)
                {
                    ShowLevelGain();
                    yield break; 
                }
                ShowExperienceGain();   
            }
        }

        private void ShowExperienceGain()
        {
            _text.text = "+1 EXP";
            StartCoroutine(FadeText(_text));
        }
        
        private void ShowLevelGain()
        {
            _text.text = "+1 LVL";
            StartCoroutine(FadeText(_text));
        }
        
        IEnumerator FadeText(TMP_Text text)
        {
            var color = text.color;
            color.a = 1f;
            text.color = color;
                
            yield return new WaitForSeconds(1f);
                
            var time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime;
                color.a = Mathf.Lerp(1f, 0f, time / 1f);
                text.color = color;
                yield return null; 
            }
                
            color.a = 0f;
            text.color = color;
        }
        
    }
}