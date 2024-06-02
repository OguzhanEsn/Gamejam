using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PushInteract", menuName = "Interactions/PushInteract")]
public class PushInteract : Interactions
{
    public string typeText = "Press F to Push Tray Rack";
    public string itemText = "Tray Rack";


    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Sink");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {

        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);

    }
}
