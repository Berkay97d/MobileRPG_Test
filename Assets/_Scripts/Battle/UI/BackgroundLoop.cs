using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Data.User;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] private Sprite[]_bgSprites;
    [SerializeField] private Image _bgImage;
    

    private void Start()
    {
        _bgImage.sprite = _bgSprites[SaveSystem.GetUserData().GetBattleCount() % 4];
    }
    
}
