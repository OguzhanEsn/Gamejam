using UnityEngine;
using UnityEngine.InputSystem;

namespace NunPlayerInput
{
    public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    private PlayerInput playerInput; //NoCashing
    private InputAction moveAction, mouseActionX, 
    mouseActionY, interactAction, scrollerActionY;

    private Vector2 mouseInput;

    public Vector2 GetMovementInput()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public float GetMouseScrollInput()
    {
       // Debug.Log("Mouse Scroll is pressed: " + scrollerActionY.ReadValue<float>());
        return scrollerActionY.ReadValue<float>();
    }

    #region - OnePushInputs -
    public bool GetInteractInput()
    {
        //Debug.Log("Interact is pressed" + playerInput.Interaction.ButtonPush.triggered);
        return playerInput.Interaction.ButtonPush.triggered;
    }

    public bool GetEscapeInput()
    {
        return playerInput.Interaction.EscapePush.triggered;
    }

    public bool GetCrouchInput()
    {
        return playerInput.Movement.Crouch.triggered;
    }

    public bool GetThrowImput()
    {
        return playerInput.Interaction.ThrowButtonPush.triggered;
    }

    public bool GetQButtonInput()
    {
        return playerInput.Interaction.QButtonPush.triggered;
    }

    #endregion
    public Vector2 GetMouseDelta()
    {
        return mouseInput = new Vector2(mouseActionX.ReadValue<float>(), 
        mouseActionY.ReadValue<float>());
    }

    private void Awake()
    {
        instance = this;
        playerInput = new PlayerInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
    // playerInput.OnGround.Jump.started += DoJump;
    moveAction = playerInput.Movement.Move;

    playerInput.Movement.Crouch.performed += ctx => GetCrouchInput();
    mouseActionX = playerInput.CameraMovement.MouseX;
    mouseActionY = playerInput.CameraMovement.MouseY;

    scrollerActionY = playerInput.Interaction.MouseScrollY;
    scrollerActionY.performed += ctx => GetMouseScrollInput();
    
    //moveAction.performed += ctx => Debug.Log(ctx.ReadValue<Vector2>());
    //mouseActionX.performed += ctx => Debug.Log(ctx.ReadValue<float>());
    //mouseActionY.performed += ctx => Debug.Log(ctx.ReadValue<float>());
    
    //playerInput.Interaction.ButtonPush.performed += ctx => Debug.Log("Interact222");
    playerInput.Interaction.ButtonPush.performed += ctx => GetInteractInput();
    playerInput.Interaction.QButtonPush.performed += ctx => GetQButtonInput();
    playerInput.Interaction.EscapePush.performed += ctx => GetEscapeInput();
    playerInput.Interaction.ThrowButtonPush.performed += ctx => GetThrowImput();

    
    playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
        
    }


}

}
