using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class TestObje : MonoBehaviour, IInteractable
{
    [SerializeField] Interactions inter;

    [SerializeField] HudHandler hudHandler; //Testing

    [SerializeField] public InventoryHandler inventoryHandler;

    [SerializeField] ItemSO itemData;


    public bool isOpen = false;

    public int inventoryNumber;

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
                
                //Destroy this later
                //Destroy(this.gameObject, 0.1f);
                break;
            case ReadInteract readInteract:
                inter.Activate(this.gameObject, hudHandler);
                hudHandler.RoutineUIOpenClose();
                break;
            case ReportInteract reportInteract:
                inter.Activate(this.gameObject, hudHandler);
                ReportPage reportPage = gameObject.GetComponent<ReportPage>();
                reportPage.PickUp();
                break;
            case FoodInteract foodInteract:
                if(foodInteract.ItemData.foodHealthType == FoodHealthType.Natural) 
                {
                    if(inventoryHandler.GetCurrentItem() is PoisonITSO)
                    {
                        PoisonITSO poision = inventoryHandler.GetCurrentItem() as PoisonITSO;
                        if (poision.poisonType == PoisionType.Poison)
                        { 
                            switch(poision.poisonPotency)
                            {
                                case PoisonPotency.Weak:
                                    foodInteract.ItemData.foodHealthType = FoodHealthType.WeakPoisoned;
                                    break;
                                case PoisonPotency.Normal:
                                    foodInteract.ItemData.foodHealthType = FoodHealthType.NormalPoisoned;
                                    break;
                                case PoisonPotency.Strong:
                                    foodInteract.ItemData.foodHealthType = FoodHealthType.StrongPoisoned;
                                    break;
                                case PoisonPotency.Fatal:
                                    foodInteract.ItemData.foodHealthType = FoodHealthType.FatalPoisoned;
                                    break;

                            }

                            

                            MeshRenderer[] foodMat = gameObject.transform.GetComponentsInChildren<MeshRenderer>(); //sonra deðiþtir

                            Material tempMat = foodInteract.ItemData.poisonedMaterial;

                            for (int i = 0; i < foodMat.Length; i++) 
                                foodMat[i].material = tempMat;

                            //gameObject.transform.parent.GetComponent<Oven>().emptyFoodHealthType = FoodHealthType.Poisioned;
                            //gameObject.transform.parent.GetComponent<Oven>().SetEmptyChanges();
                            inventoryHandler.RemoveItem();
                        }else if(poision.poisonType == PoisionType.Mental)
                        {
                            //gameObject.transform.parent.GetComponent<Oven>().emptyFoodHealthType = FoodHealthType.Mental; 
                            //gameObject.transform.parent.GetComponent<Oven>().SetEmptyChanges();
                            inventoryHandler.RemoveItem();
                        }
                    }else 
                        inventoryHandler.AddItem(foodInteract.ItemData);
                     
                }else 
                {
                inventoryHandler.AddItem(foodInteract.ItemData);
               // this.gameObject.SetActive(false);
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
                hudHandler.InventoryOpenClose(inventoryNumber);
                hudHandler.StopMovement(true);
                }
                //inter.Activate(this.gameObject, hudHandler);
                break;
            case ReleaseItemInteract releaseInteraction: //bu script, üzerine eþya konulabilir objelere de eklenecek.
                
                if(inventoryHandler.GetCurrentItem() != null)
                {
                    bool isPlaced = false;

                    string obje = inventoryHandler.GetCurrentItem().itemName;
                    if (GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
    {
                        Debug.Log(obje);
                        Debug.Log(objePrefab.parent.name);

                        foreach (Transform item in transform)
                        {
                            Debug.Log(item);
                            if (item.childCount == 0 && !isPlaced)
            {
                                objePrefab.parent = item;
                                isPlaced = true;
                                break;
                            }
                        }

                        if (isPlaced)
                        {
                            inventoryHandler.RemoveItem();
                        }
                    }

                }

                /* if (!GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
                 {
                     objePrefab = playerHand.Find("holder").Find(obje).transform;
                     if (objePrefab.parent == null)
                         objePrefab.SetParent(playerHand.Find("holder"));
                 }*/

                break;

            

            case PatientInteract patientInteract:
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


    private void OnTransformParentChanged()
    {
        Transform holderParent = GameObject.FindGameObjectWithTag("holder").GetComponent<Transform>();

        if(transform.parent == holderParent)
        {
            transform.localRotation = Quaternion.Euler(itemData.inHandRotation);
            transform.localPosition = itemData.inHandPosition;
            transform.localScale = itemData.inHandScale;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(itemData.onObjectRotation);
            transform.localPosition = itemData.onObjectPosition;
            //transform.localScale = itemData.onObjectScale;
        }
    }

}
