using UnityEngine;
using NunPlayerInput;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null; //Eyes
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
        SelectActiveSLot();
        ReleaseItem();
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
            hudHandler.InventoryOpenClose();
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
            playerHand.GetComponent<SpriteRenderer>().sprite = null;
            return;
        }

        Debug.Log("Setting Player Hand: " + inventoryHandler.GetCurrentItem().itemName.ToString());
        playerHand.GetComponent<SpriteRenderer>().sprite = inventoryHandler.GetCurrentItem().uiIcon;
        //inventoryHandler.GetCurrentItem().itemImage.transform.SetParent(playerHand);
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
            Time.timeScale = 0.1f;
        }else if(!busy)
        {
            miniGameOn = busy;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
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
                Time.timeScale = 0.1f;
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

    
    public void SelectActiveSLot()
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
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.position, playerCamera.forward * 5.0f);
    }
}
