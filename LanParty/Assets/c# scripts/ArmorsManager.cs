using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armors", menuName = "Armor", order = 1)]
public class ArmorsManager : ScriptableObject
{
    public string nome;
    public Sprite imageWeapon;
    public int dmg;
    public string rarita;
    public int cost;
}
