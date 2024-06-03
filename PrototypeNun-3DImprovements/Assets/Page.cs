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
    public TextMeshProUGUI contractText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI rankText;
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

        headIMG.sprite = patients[pageIndex].patientInfo.headImage;
        if(headIMG.sprite == null )
            headIMG.enabled = false;
        else headIMG.enabled = true;
        contactName.text = "Name: " + patients[pageIndex].patientInfo.nameText;
        roomNumber.text = "Room #: " + patients[pageIndex].patientInfo.roomNumberText;
        daysLeft.text = "Discharged in: " + patients[pageIndex].daysHeWillStay + " days.";
        daysLeftToKill.text = "Eliminate in: " + patients[pageIndex].patientInfo.daysLeftToKill + " days.";
        contractText.text = "Contract Type: " + patients[pageIndex].ContractType.ToString();
        healthText.text = "Physical Condition: " + patients[pageIndex].physicalHealth.ToString() +" / 5";
        rankText.text = "Rank: " + patients[pageIndex].targetRank.ToString();
        pageIndex++;
    }


}
