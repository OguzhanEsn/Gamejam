using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalpel : MonoBehaviour
{
    [SerializeField] WeaponITSO scalpelSO;


    private void Awake()
    {
        if (scalpelSO != null)
        {
            scalpelSO.itemName = "Scalpel";
            scalpelSO.name = "Scalpel";
            scalpelSO.isBloody = false;
        }
    }

}
