using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTray : MonoBehaviour
{
    [SerializeField] FoodITSO food;

    private void Awake()
    {
        if (food != null)
            food.foodHealthType = FoodHealthType.Natural;
    }
}
