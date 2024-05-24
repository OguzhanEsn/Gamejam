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
    public TextMeshProUGUI daysLeftToKill;
    public TextMeshProUGUI complainText;
    //add contract type
    public Patient[] patients;

    public int pageIndex = 0;

    private void Start()
    {
        SwapPage();
    }


    public void SwapPage() //ayný sayfa, sayfa üzerindeki bilgiler güncellenir.
    {
        if(pageIndex >= patients.Length) pageIndex = 0;


        contactName.text = "Target Name: " + patients[pageIndex].patientInfo.nameText;
        roomNumber.text = "Room Number: " + patients[pageIndex].patientInfo.roomNumberText;
        daysLeft.text = "Days untill Discharged: " + patients[pageIndex].daysHeWillStay;
        daysLeftToKill.text = "Must be eliminated in: " + patients[pageIndex].patientInfo.daysLeftToKill;
        complainText.text = "Complains: " + patients[pageIndex].patientInfo.complainText;

        pageIndex++;
    }


}
