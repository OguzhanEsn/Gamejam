using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Patient : MonoBehaviour, IInteractable
{
    
    //Remember to add States way way later!!

    public string firstName;
    public string lastName;
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
    public bool IsCrazy = false;

    [SerializeField] Interactions inter;
    [SerializeField] HudHandler hudHandler;
    [SerializeField] InventoryHandler inventoryHandler;

    //UI
    public Image headImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI daysLeftText;
    public TextMeshProUGUI complainText;
    public TextMeshProUGUI roomNumberText;

    bool canDestroy = false;


    #region BodyParts
    private MeshRenderer _meshRenderer;
    private MeshCollider _meshCollider;
    #endregion

    public void DecreaseHealth(ContractType contractType)
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
            default:
                break;
        }
    }

    // Start is called before the first frame update

    void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        nameText.text = firstName + " " + lastName;
        daysLeftText.text = daysHeWillStay.ToString();
        roomNumberText.text = roomNumber.ToString();
        complainText.text = "He has no Complains";    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region IInteractable
    public void Interact()
    {
        if(IsDead) return;

        switch(inter)
        {
            case PatientInteract patientInteract:
                if(inventoryHandler.GetCurrentItem() is FoodITSO && !hasDamagedToday)
                {
                    FoodITSO food = inventoryHandler.GetCurrentItem() as FoodITSO;
                    if(food.foodHealthType == FoodHealthType.Poisioned)
                    {
                        HandleFood(food.cookingType);
                        DecreaseHealth(ContractType.Kill);
                    }else if(food.foodHealthType == FoodHealthType.Mental)
                    {
                        food.cookingType = CookingType.Burned;
                        DecreaseHealth(ContractType.MakeCrazy);
                    }else if(food.foodHealthType == FoodHealthType.Natural)
                    { //Check it is raw or not ?
                        
                    }inventoryHandler.RemoveItem();
                    
                } else if(inventoryHandler.GetCurrentItem() is WeaponITSO)
                {
                    WeaponITSO weapon = inventoryHandler.GetCurrentItem() as WeaponITSO;
                    IsMurdered = true;
                    IsDead = true;
                }
                Debug.Log("Patient Interact");
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



    
    void HandleFood(CookingType cookingType)
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

    }

    public void SetDayBools()
    {
        AfterDayCheckDeath();
        hasComplain = false;
        hasDamagedToday = false;
        daysHeWillStay --;

        if(daysHeWillStay <= 0)
        {
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
    Kill,
    MakeCrazy,
}
