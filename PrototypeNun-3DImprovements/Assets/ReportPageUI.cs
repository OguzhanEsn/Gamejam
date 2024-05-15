using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ReportPageUI : MonoBehaviour
{
    public ReportISO[] reportData;

    public Page[] pages;


    public void SetPatientInfo()
    {

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].contactName.text = reportData[i].nameText.ToString();
            pages[i].roomNumber.text = reportData[i].roomNumberText.ToString();
            pages[i].daysLeft.text = reportData[i].daysLeftText.ToString();
            pages[i].complainText.text = reportData[i].complainText.ToString();

        }
    }

}
