using MiniGames;
using UnityEngine;

public class HumanoidObject : MonoBehaviour, IInteractable
{

    [SerializeField] private Interactions inter;
    [SerializeField] private HudHandler hudHandler;
    [SerializeField] private InventoryHandler inventoryHandler;
    [SerializeField] private PlayerController playerController;

    private bool isStolen = false;
    private bool isBusy = false;

    public bool IsBusy
    {
        get { return isBusy; }
        set { isBusy = value; }
    }
    public bool IsStolen
    {
        get { return isStolen; }
        set { isStolen = value; }
    }
    public Humanoid itemData;

    public void Activate()
    {
        inter.ShowInteractUI(this.gameObject, hudHandler);
    }

    public void DeInteract()
    {
        inter.Deactivate(this.gameObject, hudHandler);
    }

    public void Interact()
    {
        switch(inter)
        {
            case PocketInteractions pocketInteractions:
                Debug.Log("Pocket Interact");
                if(playerController.IsCrouching && !isBusy)
                {
                    //PickPocket
                    hudHandler.ActivateMiniGameUI( MiniGameType.PickPocket, LockDifficulty.Medium,
                    3, this.gameObject);
                    
                }else
                {
                    //PopUpTalkUI

                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
