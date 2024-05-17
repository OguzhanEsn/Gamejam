using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Food")]
public class FoodITSO : ItemSO
{

    public FoodHealthType foodHealthType = FoodHealthType.Natural;
    //public CookingType cookingType;
    //public int coockingTime;

    public Material poisonedMaterial;

    

}


public enum CookingType
{
    Raw = 0,
    PerfectCoocked= 1,
    Burned=2
}

public enum FoodHealthType
{
    Natural = 0,
    WeakPoisoned = 1,
    NormalPoisoned = 2,
    StrongPoisoned = 3,
    FatalPoisoned = 4,
    Mental = 5

}