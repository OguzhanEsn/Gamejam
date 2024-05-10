using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Poision")]
public class PoisionITSO : ItemSO
{
    public PoisionType poisionType;
    public int poisionTime;
    public int poisionDamage;
}

public enum PoisionType
{
    Poision = 0,
    Mental = 1,
    //LaterAdd Physical = 2
}