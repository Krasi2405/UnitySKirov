
using UnityEngine;
using System;

[Serializable]
class Spell
{
    [SerializeField]
    private string name;

    private int damage;

    private Sprite icon;

    private float speed;

    private float castTime;

    private GameObject spellPrefab;

    private Color barColor;

    private float castRange;

    private bool hasCastRange;

}
