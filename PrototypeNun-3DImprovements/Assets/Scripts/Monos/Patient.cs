using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Patient : MonoBehaviour, IInteractable
{
    
    //Remember to add States way way later!!

    public string firstName;
    public ContractType ContractType;


    [Range(0, 5)]
    public int mentalHealth;
    [Range(0, 5)]
    public int physicalHealth;

    [Range(1, 3)]
    public int rank;

    [Range(1, 6)]
    public int roomNumber;

    [Range(1, 5)]
    public int daysHeWillStay;
    public bool hasDamagedToday = false;
    public bool hasComplain = false;

    public bool IsMurdered = false;

    public bool IsDead = false;
    public bool IsPoisoned = false;
    public bool IsCrazy = false;

    [SerializeField] Interactions inter;
    [SerializeField] HudHandler hudHandler;
    [SerializeField] InventoryHandler inventoryHandler;
    public ReportISO patientInfo;

    //UI
    public Image headImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI daysLeftText;
    public TextMeshProUGUI complainText;
    public TextMeshProUGUI roomNumberText;
    public TextMeshProUGUI daysLeftToKillText;

    bool canDestroy = false;

    public Transform killPos;

    #region BodyParts
    private MeshRenderer _meshRenderer;
    private MeshCollider _meshCollider;
    #endregion

    public void DecreaseHealth(ContractType contractType, int damage)
    {
        if(hasDamagedToday) return;

        switch (contractType)
        {
            case ContractType.Kill:
                hasDamagedToday = true;
                physicalHealth -= 1;
                break;
            case ContractType.MakeCrazy:
                hasDamagedToday = true;
                mentalHealth -= 1;
                break;
            case ContractType.Poison:
                hasDamagedToday= true;
                physicalHealth -= damage;
                break;
            default:
                break;
        }

        if(physicalHealth <= 0)
            IsDead = true;
        else IsDead = false;

    }

    // Start is called before the first frame update

    void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        firstName = patientInfo.nameText;

        //paheadImage = patientInfo.headImage;
        nameText.text = firstName;
        daysLeftText.text = daysHeWillStay.ToString();
        roomNumberText.text = patientInfo.roomNumberText.ToString();
        complainText.text = patientInfo.complainText;
        daysLeftToKillText.text = patientInfo.daysLeftToKill.ToString();    

    }



    #region IInteractable
    public void Interact()
    {
        if(IsDead) return;

        switch(inter)
        {
            case PatientInteract patientInteract:
                if (inventoryHandler.GetCurrentItem() is FoodITSO && !hasDamagedToday)
                {
                    FoodITSO food = inventoryHandler.GetCurrentItem() as FoodITSO;

                    switch (food.foodHealthType)
                    {
                        case FoodHealthType.WeakPoisoned:
                            DecreaseHealth(ContractType.Poison, (int)FoodHealthType.WeakPoisoned);
                            IsPoisoned = true;
                            break;
                        case FoodHealthType.NormalPoisoned:
                            DecreaseHealth(ContractType.Poison, (int)FoodHealthType.NormalPoisoned);
                            IsPoisoned = true;
                            break;
                        case FoodHealthType.StrongPoisoned:
                            DecreaseHealth(ContractType.Poison, (int)FoodHealthType.StrongPoisoned);
                            IsPoisoned = true;
                            break;
                        case FoodHealthType.FatalPoisoned:
                            DecreaseHealth(ContractType.Poison, (int)FoodHealthType.FatalPoisoned);
                            IsPoisoned = true;
                            break;
                    }


                    if (food.foodHealthType == FoodHealthType.Mental)
                    {
                        //food.cookingType = CookingType.Burned;
                        //DecreaseHealth(ContractType.MakeCrazy);
                    } else if (food.foodHealthType == FoodHealthType.Natural)
                    { //Check it is raw or not ?

                    }

                    /* Transform foodTrayPlace = transform.Find("FoodTrayPlace");

                     string obje = inventoryHandler.GetCurrentItem().itemName;
                     /* if (!GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
                      {
                          objePrefab = playerHand.Find("holder").Find(obje).transform;
                          if (objePrefab.parent == null)
                              objePrefab.SetParent(playerHand.Find("holder"));
                      }
                     if (GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
                     {

                         objePrefab.parent = foodTrayPlace;

                     }
                     */
                    inventoryHandler.RemoveItem();

                } else if(inventoryHandler.GetCurrentItem() is WeaponITSO)
                {
                    WeaponITSO weapon = inventoryHandler.GetCurrentItem() as WeaponITSO;
                    PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                    Debug.Log(gameObject.name);
                    player.PlayKillAnimation(weapon, killPos);
                    Debug.Log(killPos.gameObject.name);
                    IsMurdered = true;
                    IsDead = true;
                }
                
                break;
        }
    }

    public void Activate()
    {
    inter.ShowInteractUI(this.gameObject, hudHandler);
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
        }    }
    #endregion
    


    public void AfterDayCheckDeath()
    {
        if(physicalHealth <= 0 )
        {
            SetDeath();
            return;
        }else if(mentalHealth <= 0)
        {
            SetDeath();
            return;
        }
    }

    public void SetMental()
    {
        IsCrazy = true;
    }
    public void SetDeath()
    {
        _meshCollider.enabled = false;
        _meshRenderer.enabled = false;

        // IsDead = true;


    }



    
   /* void HandleFood(CookingType cookingType)
    {
        switch(cookingType)
        {
            case CookingType.Burned:
                hasComplain = true;
                break;
            case CookingType.Raw:
                hasComplain = true;
                DecreaseHealth(ContractType.Kill);
                break;
            case CookingType.PerfectCoocked:
                break;
            default:
                break;
        }

    }*/

    public void SetDayBools()
    {
        AfterDayCheckDeath();
        hasComplain = false;
        hasDamagedToday = false;
        daysHeWillStay --;

        if(daysHeWillStay <= 0)
        {
            //decrease loyalty
            SetDeath();
            this.gameObject.SetActive(false);
            //SetNull
        }
    
    }
}

public enum Complains
{
    badCooking,
    noFeeding
}
public enum ContractType
{
    None,
    Poison,
    Kill,
    MakeCrazy,
}

public enum ContractTime
{
    oneDay = 1, twoDay = 2, threeDay = 3,
}
