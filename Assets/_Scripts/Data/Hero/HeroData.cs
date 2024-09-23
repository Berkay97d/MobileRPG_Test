using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct HeroData
{
    public int _heroID;
    public string _name;
    public float _maxHealth;
    public float _attackDamage;
    public int _experience;
    public int _level;
    public Sprite _sprite;
}
