using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReportInteract", menuName = "Interactions/ReportInteract")]
public class ReportInteract : Interactions
{
    public string reportText = "Press F to Pick Up";
    public string typeText = "Report";

    public static bool isPickedUp = false;

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Report");
        isPickedUp=true;
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, "Report", "Press F to Pick Up");
    }

}
