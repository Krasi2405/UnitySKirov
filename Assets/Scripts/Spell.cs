using System;
using UnityEngine;
[Serializable]
public class Spell{
    [SerializeField]
    private string name;

    [SerializeField]
    private int damage;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float castTime;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Color barColor;


    private float lastCasted;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private bool hasCastBar;

    private float currentCooldown;

    public string Name
    {
        get
        {
            return name;
        }


    }

    public int Damage
    {
        get
        {
            return damage;
        }


    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }


    }

    public float Speed
    {
        get
        {
            return speed;
        }


    }

    public float CastTime
    {
        get
        {
            return castTime;
        }


    }


    public Color BarColor
    {
        get
        {
            return barColor;
        }


    }



    public float LastCasted
    {
        get
        {
            return lastCasted;
        }
        set
        {
            lastCasted = value;
        }
    }

    public float Cooldown
    {
        get
        {
            return cooldown;
        }

        set
        {
            cooldown = value;
        }
    }

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }

        set
        {
            prefab = value;
        }
    }

    public bool HasCastBar
    {
        get
        {
            return hasCastBar;
        }

        set
        {
            hasCastBar = value;
        }
    }

    public float CurrentCooldown
    {
        get
        {
            return currentCooldown;
        }

        set
        {
            currentCooldown = value;
        }
    }
}
