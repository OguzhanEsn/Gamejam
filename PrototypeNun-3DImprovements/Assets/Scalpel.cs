using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

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

    public void ChangeMaterial(Material material)
    {
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material = material;

    }
}
