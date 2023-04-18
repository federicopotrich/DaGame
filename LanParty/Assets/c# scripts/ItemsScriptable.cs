using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Armor", menuName = "Item", order = 1)]
public class ItemsScriptable : ScriptableObject
{
    public string nome;
    public string Type;
    public Sprite image_weapon_Armor;
    public Sprite image_bullet;
    public bool DistanceWeapon_MeleeWeapon; /* true = distance / false = melee */ 
    public int damage;
    public int lunghezza, larghezza;
    public float range;
    public int armorResist;
    public int cost;
}
