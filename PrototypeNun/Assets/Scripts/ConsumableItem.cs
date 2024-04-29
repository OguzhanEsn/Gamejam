using UnityEngine;

public class ConsumableItem : Item, IInteractable
{

    public int healthValue;
    public CookingType cookingType;

    public bool isStackable = false;

    [SerializeField] Interactions inter;
    [SerializeField] HudHandler hudHandler; //Testing
    [SerializeField] InventoryHandler inventoryHandler;

    private MeshCollider _meshCollider;
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;

    void Awake()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = GetComponent<MeshFilter>();


    }

    void Start()
    {
       // SetIt(false);
    }

    public void SetIt(bool isOpen)
    {
        if(isOpen)
        {
            _meshCollider.enabled = true;
            _meshRenderer.enabled = true;
            
        }
        else
        {
            _meshCollider.enabled = false;
            _meshRenderer.enabled = false;
        }
    }


    public void SetConsumableItem(int healthValue, CookingType cookingType)
    {
        this.healthValue = healthValue;
        this.cookingType = cookingType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        switch(inter)
        {
            case PickInteract pickInteract:
                Debug.Log("Grab: " + pickInteract.itemData.itemName);
                inventoryHandler.AddItem(pickInteract.itemData);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject, 0.1f);
                break;
            case ReadInteract readInteract:
                inter.Activate(this.gameObject, hudHandler);
                break;
            default:
                break;
        }
    }

    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        if(this.gameObject == null) return;
        inter.Deactivate(this.gameObject, hudHandler);
    }
}

