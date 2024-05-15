using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Page : MonoBehaviour
{
    public Image headIMG;
    public TextMeshProUGUI contactName;
    public TextMeshProUGUI roomNumber;
    public TextMeshProUGUI daysLeft;
    public TextMeshProUGUI complainText;
    //add contract type
    public Patient[] patients;

    public int pageIndex = 0;

    public void SwapPage() //ayný sayfa, sayfa üzerindeki bilgiler güncellenir.
    {
        if(pageIndex >= patients.Length) pageIndex = 0;


        contactName.text = patients[pageIndex].patientInfo.nameText;
        roomNumber.text = patients[pageIndex].patientInfo.roomNumberText;
        daysLeft.text = patients[pageIndex].patientInfo.daysLeftText;
        complainText.text = patients[pageIndex].patientInfo.complainText;

        pageIndex++;
    }


}
