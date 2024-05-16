using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReleaseItemInteract", menuName = "Interactions/ReleaseItemInteract")]
public class ReleaseItemInteract : Interactions
{
    public string typeText = "Press F to Put Item";
    public string itemText = "Cabinet";

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Releasing");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        foreach (Transform child in go.transform)
        {
            if (child.childCount == 0)
                hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
            else
                return;

        }

        
    }
}
