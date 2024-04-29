using MiniGames;
using Unity.VisualScripting;
using UnityEngine;

public class TestObje : MonoBehaviour, IInteractable
{
    [SerializeField] Interactions inter;

    [SerializeField] HudHandler hudHandler; //Testing

    [SerializeField] InventoryHandler inventoryHandler;

    [SerializeField] ItemSO itemData;

    public bool isInOwen = false;
    public bool isOpen = false;

    private bool canDestroy = false;
    public ItemSO ItemData
    {
        get { return itemData; }
        set { itemData = value; }
    }

    

    public void Interact()
    {
        //
        switch(inter)
        {
            case PickInteract pickInteract:
                Debug.Log("Grab: " + pickInteract.itemData.itemName);
                inventoryHandler.AddItem(pickInteract.itemData);
                this.gameObject.SetActive(false);
                //Destroy this later
                //Destroy(this.gameObject, 0.1f);
                break;
            case ReadInteract readInteract:
                inter.Activate(this.gameObject, hudHandler);
                break;
            case FoodInteract foodInteract:
                if(isInOwen) 
                {
                    if(inventoryHandler.GetCurrentItem() is PoisionITSO)
                    {
                        PoisionITSO poision = inventoryHandler.GetCurrentItem() as PoisionITSO;
                        if(poision.poisionType == PoisionType.Poision)
                        {
                            gameObject.transform.parent.GetComponent<Oven>().emptyFoodHealthType = 
                            FoodHealthType.Poisioned;
                            gameObject.transform.parent.GetComponent<Oven>().SetEmptyChanges();
                            inventoryHandler.RemoveItem();
                        }else if(poision.poisionType == PoisionType.Mental)
                        {
                            gameObject.transform.parent.GetComponent<Oven>().emptyFoodHealthType = 
                            FoodHealthType.Mental;
                            gameObject.transform.parent.GetComponent<Oven>().SetEmptyChanges();
                            inventoryHandler.RemoveItem();
                        }
                    }else {
                    Debug.Log("Food Interact Oven");
                    gameObject.transform.parent.GetComponent<Oven>().SetEmpty(true);
                    inventoryHandler.AddItem(foodInteract.ItemData);
                    this.gameObject.SetActive(false);
                    DeInteract();
                         }
                }else 
                {
                inventoryHandler.AddItem(foodInteract.ItemData);
                Debug.Log("Food Interact Floor");
               // this.gameObject.SetActive(false);
                canDestroy = true;
                DeInteract();
                //this.gameObject.SetActive(false);
                }
                break;
            case LockerInteraction lockerInteraction:
            Debug.Log("Locker Interact");
            if(!isOpen)
                {
                if(lockerInteraction.LockerData is LockerITSO && 
                inventoryHandler.GetCurrentItem() is KeyITSO)
                {
                    LockerITSO locker = lockerInteraction.LockerData;
                    KeyITSO key = inventoryHandler.GetCurrentItem() as KeyITSO;
                    int lockpickNumber = inventoryHandler.GetCurrentItemNumber();
                    if(key.keyType == KeyTypes.lockpick)
                    {
                        hudHandler.ActivateMiniGameUI(MiniGameType.LockPick, 
                        locker.lockDifficulty, lockpickNumber, this.gameObject);
                        //OPEN MINI GAME HERE
                    }else if(key.keyType == KeyTypes.specialKey)
                    {
                        if(key.keyID == this.itemData.GetComponent<LockerITSO>().LockerID)
                        {
                            //OpenLocker
                            isOpen = true;
                        }
                    }
                  }
                }else {                
                hudHandler.InventoryOpenClose();
                hudHandler.StopMovement(true);
                }
                //inter.Activate(this.gameObject, hudHandler);
                break;
            default:
                break;
        }
       
       // inter.Activate(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        if(this == null) return;    
        //
        if(this.gameObject == null) return;

        inter.Deactivate(this.gameObject, hudHandler);

        if(canDestroy) 
        {
            Destroy(this.gameObject);
        }
    }

    public void Activate()
    {
        //
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

}
