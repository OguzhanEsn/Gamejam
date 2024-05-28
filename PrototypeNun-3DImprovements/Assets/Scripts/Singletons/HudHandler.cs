using MiniGames;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public enum UIElements
{
    InteractableUI= 0,
    InventoryUI = 1,
    DialogueUI= 2,
    PauseUI= 3,
    RoutineUI = 4,
}
public class HudHandler : MonoBehaviour
{
    [SerializeField] GameObject interactableUI = null;
    [SerializeField] public GameObject inventoryUI = null;  //PickPocketUI
    [SerializeField] GameObject dialogueUI = null;
    [SerializeField] GameObject pauseUI = null;
    [SerializeField] GameObject raporUI= null;
    [SerializeField] GameObject routineUI = null;

    [SerializeField] PlayerController playerController = null;

    [SerializeField] public GameObject fridgeInventoryUI = null;
    [SerializeField] public GameObject lockerInventoryUI = null;
    [SerializeField] public GameObject deskInventoryUI = null;

    #region MiniGameUI
    [SerializeField] GameObject MiniGameUI = null;
    [SerializeField] GameObject LockPickMiniGameUI = null;
    [SerializeField] GameObject trueLockPickGame = null;
    [SerializeField] GameObject PickPocketMiniGameUI = null;
    [SerializeField] GameObject prayMiniGameUI = null;

    #endregion

    #region Cheat
    public List<GameObject> movables = new List<GameObject>();
    #endregion


    [SerializeField] TextMeshProUGUI interactableTypeText = null, interactableItemText = null;


    public void CloseAllInventory()
    {
        fridgeInventoryUI.SetActive(false);
        lockerInventoryUI.SetActive(false);
        deskInventoryUI.SetActive(false);
        inventoryUI.SetActive(false);
        routineUI.SetActive(false);
        Test(false);
        Cursor.visible = false;

    }
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

    public void RaporUIOpenClose()
    {
        if(raporUI.activeSelf)
        {
            raporUI.SetActive(false);
            playerController.SetBusy(raporUI.activeSelf);
        }
        else
        {
            raporUI.SetActive(true);
            playerController.SetBusy(raporUI.activeSelf);
        }
    }

    public void RoutineUIOpenClose()
    {
        if (!routineUI.activeSelf)
        {
            Debug.Log("123");
            routineUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    public void InventoryOpenClose(int number)
    {
        switch (number)
        {
            case 0:
                if(!fridgeInventoryUI.activeSelf)
                {
                    fridgeInventoryUI.SetActive(true);
                    Test(true);
                }
                break;
            case 1:
                if(!lockerInventoryUI.activeSelf)
                {
                    lockerInventoryUI.SetActive(true);
                    Test(true);
                }
                break;
            case 2:
                if(!deskInventoryUI.activeSelf)
                {
                    deskInventoryUI.SetActive(true);
                    Test(true);
                }
                break;
            case 3:
                if(!inventoryUI.activeSelf)
                {
                    inventoryUI.SetActive(true);
                    Test(true);
                }
                break;
        }

    }


   void Test(bool test)
   {
    foreach (GameObject obj in movables)
        {
            // Eğer obje Ipatrol arayüzünü uyguluyorsa
            if (obj.GetComponent<PatrolAI>() != null)
            {
                obj.GetComponent<NavMeshAgent>().isStopped = test;
            }
        }
   }
    

   public void CloseMiniGameUI()
    {
        MiniGameUI.SetActive(false);
        LockPickMiniGameUI.SetActive(false);
        lockerInventoryUI.SetActive(false);
        fridgeInventoryUI.SetActive(false);
        deskInventoryUI.SetActive(false);

        PickPocketMiniGameUI.SetActive(false);
        playerController.SetBusy(false);

        

        foreach (GameObject obj in movables)
        {
            // Eğer obje Ipatrol arayüzünü uyguluyorsa
            if (obj.GetComponent<PatrolAI>() != null)
            {
                obj.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }

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

            case MiniGameType.Pray:
                prayMiniGameUI.SetActive(true);
                playerController.SetBusy(true);
                
        
        foreach (GameObject obj in movables)
        {
            // Eğer obje Ipatrol arayüzünü uyguluyorsa
            if (obj.GetComponent<PatrolAI>() != null)
            {
                obj.GetComponent<NavMeshAgent>().isStopped = true;

            }
        }


                break;
            case MiniGameType.PickPocket:
                PickPocketMiniGameUI.GetComponent<TubeGame>().winObject = testObje;
                PickPocketMiniGameUI.SetActive(true);
                PickPocketMiniGameUI.GetComponent<TubeGame>().FirstStart(); 
                playerController.SetBusy(true);

        foreach (GameObject obj in movables)
        {
            // Eğer obje Ipatrol arayüzünü uyguluyorsa
            if (obj.GetComponent<PatrolAI>() != null)
            {
                obj.GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
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
            case UIElements.RoutineUI:
                routineUI.SetActive(true);
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
    PickPocket= 1,
    Pray = 2
}