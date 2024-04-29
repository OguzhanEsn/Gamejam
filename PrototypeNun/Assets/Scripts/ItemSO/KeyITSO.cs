using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Key")]
public class KeyITSO : ItemSO
{
    public KeyTypes keyType;
    public int keyID;


    
}


public enum KeyTypes
{
    lockpick = 0,
    specialKey = 1,
}