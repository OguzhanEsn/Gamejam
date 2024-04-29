using MiniGames;
using UnityEngine;


[CreateAssetMenu(fileName = "LockInteract", menuName = "Interactions/LockInteract")]
public class LockerInteraction : Interactions
{
    public string typeText = "Open Locker";
    public string itemText;
  //  public LockDifficulty lockDifficulty;
    public LockerITSO LockerData;
    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Locker Activated");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {
        LockerITSO lockerData = go.GetComponent<TestObje>().ItemData as LockerITSO;
        LockerData = lockerData;
        itemText = lockerData.itemName + " ( " + lockerData.lockDifficulty + " ) ";
        hudHandler.ActivateHudElement(UIElements.InteractableUI, go.transform, 1.0f, typeText, itemText);
    }
}
