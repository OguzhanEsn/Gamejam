using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrayInteract", menuName = "Interactions/PrayInteract")]
public class PrayInteract : Interactions
{
    public string prayText = "Press F to pray";
    public string typeText = "Pray";

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Praying");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, "Pray", "Press F to pray");
    }

}
