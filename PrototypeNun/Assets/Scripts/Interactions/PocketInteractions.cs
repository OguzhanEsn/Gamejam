using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PocketInteractions", menuName = "Interactions/PocketInteractions")]
public class PocketInteractions : Interactions
{
    public string typeText = "Steal";
    public string itemText;
    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Stealing");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        Humanoid itemData = go.GetComponent<HumanoidObject>().itemData;
        itemText = itemData.firstName;

        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }
}
