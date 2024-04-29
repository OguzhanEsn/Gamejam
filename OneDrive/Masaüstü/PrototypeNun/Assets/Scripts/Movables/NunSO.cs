using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nun", menuName = "Humanoid/Nun", order = 1)]
public class NunSO : Humanoid
{
    public NunType nunType;

    public string firstName;
}

public enum NunType
{
    Nun,
    MotherSuperior,
}
