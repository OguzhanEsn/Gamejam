using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "ReportSO", menuName = "ReportSO/Reports")]
public class ReportISO : ScriptableObject
{

    public Sprite headImage;
    public string nameText;
    public int daysLeftText;
    public int daysLeftToKill;
    public string complainText;
    public int roomNumberText;
    public int physicalHealth;
}
