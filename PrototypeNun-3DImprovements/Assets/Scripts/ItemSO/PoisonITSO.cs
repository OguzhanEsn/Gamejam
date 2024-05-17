using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Poision")]
public class PoisonITSO : ItemSO
{
    public PoisionType poisonType;
    public PoisonPotency poisonPotency;
}



public enum PoisionType
{
    Poison = 0,
    Mental = 1,
    //LaterAdd Physical = 2
}

public enum PoisonPotency
{
    Weak = 1, //hasarlar
    Normal = 2, 
    Strong = 3, 
    Fatal = 10, 
}

