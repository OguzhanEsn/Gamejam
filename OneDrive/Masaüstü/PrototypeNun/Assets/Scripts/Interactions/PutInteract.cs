using UnityEngine;

[CreateAssetMenu(fileName = "PutInteract", menuName = "Interactions/PutInteract")]
public class PutInteract : Interactions
{
    public string typeText = "Put";
    public string itemText;
    public ItemSO itemData;

    public override void Activate(GameObject go, HudHandler huSdHandler)
    {
        Debug.Log("Putting");
        if(go.GetComponent<Oven>().IsEmpty)
        {
            
            //Put
            go.GetComponent<Oven>().IsEmpty = false;
        }
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        if(go.GetComponent<Oven>().IsEmpty)
        {
            //YouCanPut
            hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
        }else 
        {
            hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, "Its full,you cant put", itemText);
        }


        //hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }
}
