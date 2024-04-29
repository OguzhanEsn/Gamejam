using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Food")]
public class FoodITSO : ItemSO
{

    public FoodHealthType foodHealthType;
    public CookingType cookingType;
    public int coockingTime;


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
    Poisioned = 1,
    Mental = 2

}