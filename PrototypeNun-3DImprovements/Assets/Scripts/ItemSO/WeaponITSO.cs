using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Weapon")]
public class WeaponITSO : ItemSO
{   
    public int weaponDamage;
    public Material bloodyMat;
    public bool isBloody = false;
}
