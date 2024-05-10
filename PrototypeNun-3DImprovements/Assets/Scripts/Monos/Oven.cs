using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oven : MonoBehaviour, IInteractable
{
    [SerializeField] Interactions inter;
    [SerializeField] HudHandler hudHandler; //Testing
    [SerializeField] InventoryHandler inventoryHandler;

    [SerializeField] private GameObject emptyItem;

    //public GameObject cookingItem;

    [Range(0, 100)]
    [SerializeField] int gassLevel = 100;

    [SerializeField] Transform cookPoint;
    public List<FoodITSO> foodList = new List<FoodITSO>();

    public bool IsEmpty = true;

    public CookingType emptyCookingType; 
    public FoodHealthType emptyFoodHealthType;

    public float nextCookingTime = 0;


    public void SetEmpty(bool isEmpty)
    {
        IsEmpty = isEmpty;
    }

    public void Activate()
    {
        //
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        if(this.gameObject == null) return;
        inter.Deactivate(this.gameObject, hudHandler);
    }

    public void Interact()
    {
        if(inter is PutInteract putInteract && IsEmpty)
        {
            Debug.Log("Putting");
            //INEEDPLAYERSELECTEDITEM
            if(IsEmpty && inventoryHandler.GetCurrentItem() != null)
            {
                if(inventoryHandler.GetCurrentItem() is FoodITSO)
                {
                    
                  //  emptyItem = inventoryHandler.GetCurrentItem().itemPrefab;
                    //Setting Position
                    emptyItem.transform.position = cookPoint.position;
                    emptyItem.transform.rotation = Quaternion.identity;
                    
                    //item.GetComponent<ConsumableItem>().SetIt(true);
                    emptyItem.SetActive(true);

                    emptyItem.GetComponent<TestObje>().ItemData = inventoryHandler.GetCurrentItem();
                    emptyItem.GetComponent<TestObje>().isInOwen = true;
                    inventoryHandler.RemoveItem();

                    FoodITSO emptyFoodData = emptyItem.GetComponent<TestObje>().ItemData as FoodITSO;

                    emptyCookingType = emptyFoodData.cookingType;
                    emptyFoodHealthType = emptyFoodData.foodHealthType;

                    nextCookingTime = emptyFoodData.coockingTime;

                 //   emptyCookingType = emptyItem.GetComponent<TestObje>().
                 //   ItemData.GetComponent<FoodITSO>().cookingType;

                 //   emptyFoodHealthType = emptyItem.GetComponent<TestObje>().
                 //   ItemData.GetComponent<FoodITSO>().foodHealthType;

                    Debug.Log("Empty Cooking Type: " + emptyCookingType);
                    Debug.Log("Empty Food Health Type: " + emptyFoodHealthType);

                  //  emptyItem.transform.SetParent(this.gameObject.transform);
                    
                    IsEmpty = false;

                    //Start Cooking
                    //cookingItem = Instantiate(Consumable.itemPrefab, cookPoint.position, Quaternion.identity);
                    //inventoryHandler.RemoveItem(Consumable);
                }
                //Put
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void SetEmptyChanges()
   {
     ChangeEmptyItem(emptyCookingType, emptyFoodHealthType);
   }

   
    void SetNextCookingTime(float newTime)
    {
        nextCookingTime = newTime;
        //emptyCookingType = emptyItem.GetComponent<TestObje>().ItemData.GetComponent<FoodITSO>().cookingType;
        //emptyFoodHealthType = emptyItem.GetComponent<TestObje>().ItemData.GetComponent<FoodITSO>().foodHealthType;
        //nextCookingTime = emptyItem.GetComponent<TestObje>().ItemData.GetComponent<FoodITSO>().coockingTime;
    }
    void ChangeEmptyItem(CookingType cookingType, FoodHealthType foodHealthType)
    {
       foreach(FoodITSO food in foodList)
       {
           if(food.cookingType == cookingType && food.foodHealthType == foodHealthType)
           {
               emptyItem.GetComponent<TestObje>().ItemData = food;
           }
       }
    }
    


    // Update is called once per frame
    void Update()
    {
        if(!IsEmpty)
        {
            if(nextCookingTime > 0)
            {
                nextCookingTime -= Time.deltaTime;
            }else if(nextCookingTime <= 0)
            { 
                //Process to new Item
                switch(emptyCookingType)
                {
                    case CookingType.Raw:
                        emptyCookingType = CookingType.PerfectCoocked;
                        ChangeEmptyItem(CookingType.PerfectCoocked, emptyFoodHealthType);
                        SetNextCookingTime(25);
                        Debug.Log("Raw");
                        break;
                    case CookingType.PerfectCoocked:
                        emptyCookingType = CookingType.Burned;
                        ChangeEmptyItem(CookingType.Burned, emptyFoodHealthType);
                        SetNextCookingTime(25);
                        Debug.Log("Perfect");
                        break;
                    case CookingType.Burned:
                        SetNextCookingTime(0);

                        //DestoyItem ?
                        Debug.Log("Burned");
                        break;
                }

            }
            //Starts Coocking

        }
        
    }
}
