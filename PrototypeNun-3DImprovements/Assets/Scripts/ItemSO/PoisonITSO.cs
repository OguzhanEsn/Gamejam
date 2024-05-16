using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Poision")]
public class PoisonITSO : ItemSO
{
    public PoisionType poisonType;
    public int poisionTime;
    public int poisionDamage;
}

public enum PoisionType
{
    Poison = 0,
    Mental = 1,
    //LaterAdd Physical = 2
}