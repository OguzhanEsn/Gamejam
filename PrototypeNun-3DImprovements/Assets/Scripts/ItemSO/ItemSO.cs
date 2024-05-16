using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Items")]
public class ItemSO: ScriptableObject
{
    public Sprite uiIcon;
    public GameObject itemPrefab;
    
    public string itemName;
    public string itemDescription;
    public int itemID;
    public bool isStackable;

    public Vector3 inHandPosition;
    public Vector3 inHandRotation;
    public Vector3 inHandScale;

    public Vector3 onObjectPosition;
    public Vector3 onObjectRotation;
    public Vector3 onObjectScale;
}