using System;
using UnityEngine;

[Serializable]
public struct HeroData
{
    private static int MS_UPGRADERATIO = 10;

    public int _heroID;
    public string _name;
    public float _startMaxHealth;
    public float _startAttackDamage;
    public int _experience;
    public Sprite _sprite;

    public float GetMaxHealth()
    {
        int level = _experience / 5;
        return _startMaxHealth * (1 + (level * MS_UPGRADERATIO / 100f));
    }

    public float GetAttackDamage()
    {
        int level = _experience / 5;
        return _startAttackDamage * (1 + (level * MS_UPGRADERATIO / 100f));
    }
}