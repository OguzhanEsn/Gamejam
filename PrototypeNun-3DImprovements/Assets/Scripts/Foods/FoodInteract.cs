using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "FoodInteract", menuName = "Interactions/FoodInteract")]
public class FoodInteract : Interactions
{
    public string typeText = "Pick";
    public string foodNameText  = "Food Name";
    public string foodCookingTypeText = "Cooking Type";
    private string itemText;
    public FoodITSO ItemData;
    public CookingType cookingType;

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Picking");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        itemText = " ";
        FoodITSO itemData = go.GetComponent<TestObje>().ItemData as FoodITSO; 
        ItemData = itemData;
        itemText = itemData.itemName + "(" + itemData.cookingType + ")" + " - " + itemData.foodHealthType;
        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }
}
