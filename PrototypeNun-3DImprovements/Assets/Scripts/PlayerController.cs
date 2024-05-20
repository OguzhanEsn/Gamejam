using UnityEngine;
using NunPlayerInput;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;
using DG.Tweening;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null; //Eyes
    [SerializeField] Animator animator;
    [SerializeField] Transform camHolder;
    [SerializeField] Transform holder;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool lockCursor = true;

    private bool isCrouching = false;

    private bool isBusy = false;

    private bool miniGameOn = false;
    public bool IsCrouching
    {
        get { return isCrouching; }
        set { isCrouching = value; }
    }

    public bool IsBusy
    {
        get { return isBusy; }
        set { isBusy = value; }
    }

    //Testing
    [SerializeField] GameObject interactableUI;
    [SerializeField] HudHandler hudHandler;
    [SerializeField] InventoryHandler inventoryHandler;
    [SerializeField] Transform playerHand;

    #region PlayerStats
    [SerializeField] float crouchHeight;
    [SerializeField] float standHeight;
    [SerializeField] float transSpeed;
    [SerializeField] float normalSpeed = 9f;
    [SerializeField] float crouchSpeed = 3f;
    #endregion

    private IInteractable _interactable;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    private InputHandler _inputHandler;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(lockCursor)
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
        }
        animator.enabled = false;
    }

    void Update()
    {
        if(miniGameOn)
        {
            ESCCheck();
            return;
        }


        ESCMenu();

        if(isBusy) return;

        //UpdateMouseLook();
        UpdateMovement();
        InteractCheck();
        //SelectActiveSLot();
        ReleaseItem();
        SetPlayerHand();
    }

    void LateUpdate()
    {
        if(miniGameOn)
        {
            ESCCheck();
            return;
        }

        if(isBusy) return;

        UpdateMouseLook();
       // InteractCheck();

    }

    void FixedUpdate()
    {

    }
    void ESCCheck()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            hudHandler.CloseAllInventory();
            miniGameOn = false;

        }
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Vector2 targetMouseDelta = _inputHandler.GetMouseDelta().normalized * 0.5f;

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        if(_inputHandler.GetCrouchInput())
        {
            isCrouching = !isCrouching;
        }

        if(isCrouching)
        {
            HandleCrouch();
            walkSpeed = crouchSpeed;
        }else if(!isCrouching)
        {
            HandleStand();
            walkSpeed = normalSpeed;
        }

       // Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       Vector2 targetDir = _inputHandler.GetMovementInput();
       
       targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;
		
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }

    void SetPlayerHand()
    {
        if(inventoryHandler.GetCurrentItem() == null)
        {

            foreach (Transform item in holder)
            {
                item.gameObject.SetActive(false);
            }
            return;
            //playerHand.GetComponent<SpriteRenderer>().sprite = null;

        }
        else
        {
            /*Transform holder = playerHand.Find("holder");
            Debug.Log(inventoryHandler.GetCurrentItem().name);
            Transform heldItem = holder.Find(inventoryHandler.GetCurrentItem().name).GetComponent<Transform>();

            heldItem.gameObject.SetActive(true);*/
            Transform holder = playerHand.Find("holder");
            foreach (Transform item in holder)
            {

                if (holder.Find(inventoryHandler.GetCurrentItem().itemName) == item)
                {
                    Debug.Log(inventoryHandler.GetCurrentItem().itemName);
                    item.gameObject.SetActive(true);
                }else
                    item.gameObject.SetActive(false);

            }
            

            
        }
        

        /* else
        {

            ItemSO selectedItem = inventoryHandler.GetCurrentItem();
            string selectedItemName = selectedItem.itemName;
            Debug.Log(selectedItemName + "123");
            Transform findItem = FindObjectOfType<Transform>(true);


            if (findItem != null )
            {
                findItem.gameObject.transform.SetParent(playerHand);
                if (findItem.IsChildOf(playerHand))
                {
                    Debug.Log("SKJDLAFHA");
                    if (findItem.name == selectedItemName)
                    {
                        
                        findItem.gameObject.SetActive(true);
                        
                    }
                }
            }

          
            
        }*/

        //Debug.Log("Setting Player Hand: " + inventoryHandler.GetCurrentItem().itemName.ToString());
        //playerHand.GetComponent<SpriteRenderer>().sprite = inventoryHandler.GetCurrentItem().uiIcon;
        string obje = inventoryHandler.GetCurrentItem().itemName;
       /* if (!GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
        {
            objePrefab = playerHand.Find("holder").Find(obje).transform;
            if (objePrefab.parent == null)
                objePrefab.SetParent(playerHand.Find("holder"));
        }*/
        if (GameObject.Find(obje).TryGetComponent<Transform>(out var objePrefab))
        {

            objePrefab.parent = holder;
            
        }
       
        //inventoryHandler.GetCurrentItem().itemImage.transform.SetParent(playerHand);
    }

    public void PlayKillAnimation(WeaponITSO weaponType, Transform killPos)
    {
        SetBusy(true);

        if(!animator.isActiveAndEnabled)
            animator.enabled = true;

        if (weaponType == null)
        {
            Debug.LogError("weaponType is null.");
            return;
        }
        if (killPos == null)
        {
            Debug.LogError("killPos is null.");
            return;
        }

        switch (weaponType.name)
        {
            case "Knife":
                transform.position = killPos.position;
                animator.enabled = true;
                animator.Play("KnifeKillAnim");
                Debug.Log("Playing KnifeKillAnim");
                break;
            default:
                Debug.LogWarning("Weapon type not handled: " + weaponType.name);
                break;
        }
    }

    public void SetBusyAnimEvent()
    {
        /* SetBusy(Convert.ToBoolean(_event.intParameter));
         if (_event.intParameter == 0)
         {
             animator.enabled = false;
             Transform holder = playerHand.Find("holder");
             holder.localRotation = Quaternion.Euler(0f, 0f, 0f);
             holder.localPosition = Vector3.zero;
         }
             */

        SetBusy(false);

    }

    void ReleaseItem()
    {
        if(InputHandler.instance.GetThrowImput())
        {
            inventoryHandler.RemoveItem();
        }
    }
    void InteractCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if(Physics.Raycast(ray, out hit, 5.0f))
        {
            if(hit.collider.TryGetComponent(out IInteractable interactable))
            {
                Debug.Log("Interactable");
                _interactable = interactable;
                interactable.Activate();

                
                if(_inputHandler.GetInteractInput())
                {
                     interactable.Interact();
                }
            }else if(_interactable != null)
            {
                DeactivateElement();
            }

        }else if(_interactable != null)
        {
            DeactivateElement();
        }
    }


    void HandleCrouch()
    {
        if(controller.height > crouchHeight)
        {
            UpdateCharacterHeight(crouchHeight);
        }
    }

    void HandleStand()
    {
        if(controller.height < standHeight)
        {
            UpdateCharacterHeight(standHeight);
        }
    }

    void UpdateCharacterHeight(float newHeight)
    {
        controller.height = Mathf.Lerp(controller.height, newHeight, 
        Time.deltaTime * transSpeed);
    }


    public void SetBusy(bool busy)
    {
        if(busy)
        {
            miniGameOn = busy;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Time.timeScale = 0.1f;
        }else
        {
            miniGameOn = busy;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
            animator.enabled = false;
        }
    }


    void ESCMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isBusy = !isBusy;
            if(isBusy)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //Time.timeScale = 0.1f;
            }else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
            }
        }
    }

    void DeactivateElement()
    {
        _interactable.DeInteract();
        _interactable = null;    
    }

    
 /*   public void SelectActiveSLot()
    {
        int slot = 0;
        if(_inputHandler.GetMouseScrollInput() > 0)
        {
            slot = -1;
            inventoryHandler.ChangeSelectedSlot(slot);    
        }else if(_inputHandler.GetMouseScrollInput() < 0)
        {
            slot = 1;
            inventoryHandler.ChangeSelectedSlot(slot); 
        }


        SetPlayerHand();
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.position, playerCamera.forward * 5.0f);
    }
}
