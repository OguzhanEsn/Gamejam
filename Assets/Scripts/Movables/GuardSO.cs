using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guard", menuName = "Humanoid/Guard", order = 1)]
public class GuardSO : Humanoid
{
    public GuardType guardType;
}

public enum GuardType
{
    Guard,
    EliteGuard,
    Boss
}
