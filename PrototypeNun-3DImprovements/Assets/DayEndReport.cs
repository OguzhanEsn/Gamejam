using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayEndReport : MonoBehaviour
{
    public TextMeshProUGUI reportText; // Assign this in the Inspector
    public float letterDelay = 0.05f; // Delay between each letter

    private void Start()
    {
        // Example usage
        StartCoroutine(ShowEndOfDayReport("DAY 1 REPORT\nTargets killed: 3\nNon-Targets Killed: 1\nPatients Tended: 7\nPatients not Tended: 0\nSuspicion Level: 4\nLoyalty Level: 10"));
    }

    public IEnumerator ShowEndOfDayReport(string reportContent)
    {
        reportText.text = "";
        foreach (char letter in reportContent.ToCharArray())
        {
            reportText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    // Call this method when you want to display the report
    public void DisplayReport(int targetsKilled, int nonTargetsKilled, int patientsTended, int patientsNotTended, int suspicionLevel, int loyaltyLevel)
    {
        string reportContent = $"Targets killed: {targetsKilled}\nNon-Targets Killed: {nonTargetsKilled}\nPatients Tended: {patientsTended}\nPatients not Tended: {patientsNotTended}\nSuspicion Level: {suspicionLevel}\nLoyalty Level: {loyaltyLevel}";
        StartCoroutine(ShowEndOfDayReport(reportContent));
    }
}
