using MiniGames;
using UnityEngine;
using TMPro;

public enum UIElements
{
    InteractableUI= 0,
    InventoryUI = 1,
    DialogueUI= 2,
    PauseUI= 3
}
public class HudHandler : MonoBehaviour
{
    [SerializeField] GameObject interactableUI = null;
    [SerializeField] GameObject inventoryUI = null;
    [SerializeField] GameObject dialogueUI = null;
    [SerializeField] GameObject pauseUI = null;

    [SerializeField] PlayerController playerController = null;


    #region MiniGameUI
    [SerializeField] GameObject MiniGameUI = null;
    [SerializeField] GameObject LockPickMiniGameUI = null;
    [SerializeField] GameObject trueLockPickGame = null;
    [SerializeField] GameObject PickPocketMiniGameUI = null;
    #endregion


    [SerializeField] TextMeshProUGUI interactableTypeText = null, interactableItemText = null;


    // Start is called before the first frame update
    void Start()
    {
        interactableUI.SetActive(false);
        //inventoryUI.SetActive(false);
        //dialogueUI.SetActive(false);
        //pauseUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   public void InventoryOpenClose()
    {
        if(inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }
        else
        {
            inventoryUI.SetActive(true);
        }
    }

   public void CloseMiniGameUI()
    {
        MiniGameUI.SetActive(false);
        LockPickMiniGameUI.SetActive(false);
        PickPocketMiniGameUI.SetActive(false);
        playerController.SetBusy(false);
    }
   public void ActivateMiniGameUI(MiniGameType miniGameType, 
   LockDifficulty lockDifficulty, int lockPickNumber, GameObject testObje)
    {
        MiniGameUI.SetActive(true);
        switch (miniGameType)
        {
            case MiniGameType.LockPick:
                LockPickMiniGameUI.SetActive(true);
                trueLockPickGame.SetActive(true);
                trueLockPickGame.GetComponent<LockGame>().LockDifficulty = lockDifficulty;
                trueLockPickGame.GetComponent<LockGame>().RemainingLockPicks = lockPickNumber;
                trueLockPickGame.GetComponent<LockGame>().winObject = testObje;
                trueLockPickGame.GetComponent<LockGame>().FirstStart();
                playerController.SetBusy(true);
                
                break;
            case MiniGameType.PickPocket:
                PickPocketMiniGameUI.GetComponent<TubeGame>().winObject = testObje;
                PickPocketMiniGameUI.SetActive(true);
                PickPocketMiniGameUI.GetComponent<TubeGame>().FirstStart(); 
                playerController.SetBusy(true);
                break;
        }
    }


    public void ActivateHudElement(UIElements uiElemenent ,Transform ancTransform, float timeSpeed, string type, string item)
    {
        switch (uiElemenent)
        {
            case UIElements.InteractableUI:
                interactableUI.SetActive(true);
                OpenElement(interactableUI, ancTransform, timeSpeed, type, item);
                break;
            case UIElements.InventoryUI:
                inventoryUI.SetActive(true);
                break;
            case UIElements.DialogueUI:
                dialogueUI.SetActive(true);
                break;
            case UIElements.PauseUI:
                dialogueUI.SetActive(true);
                break;
        }
    }


    public void StopMovement(bool stopMovement)
    {
        playerController.SetBusy(stopMovement);
    }
    public void DeactivateElement()
    {
        interactableUI.SetActive(false);

       // inventoryUI.SetActive(false);
       // dialogueUI.SetActive(false);
       // pauseUI.SetActive(false);
    }
    

    void OpenElement(GameObject go, Transform ancTransform, float timeSpeed, string type, string item)
    {
       // go.transform.DOMove(ancTransform.position, timeSpeed);
        interactableTypeText.text = type;
        interactableItemText.text = item;
    
    }


}


public enum MiniGameType
{
    LockPick = 0,
    PickPocket= 1
}