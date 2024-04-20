using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ReadInteract", menuName = "Interactions/ReadInteract")]
public class ReadInteract : Interactions
{

    public string readText = "Press E to read";
    public string typeText = "Read";
    public string itemText;

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        //hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f);
        Debug.Log("Reading");   
    }
    
    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
        //hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f);
    }
}
