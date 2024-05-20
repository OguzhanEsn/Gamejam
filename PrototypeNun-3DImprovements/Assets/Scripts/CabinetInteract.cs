using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CabinetInteract", menuName = "Interactions/CabinetInteract")]
public class CabinetInteract : Interactions
{
    public string typeText = "Open";
    public string itemText;
    public ItemSO itemData;

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Opening");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        itemData = go.GetComponent<TestObje>().ItemData;
        itemText = itemData.itemName;

        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }
}
