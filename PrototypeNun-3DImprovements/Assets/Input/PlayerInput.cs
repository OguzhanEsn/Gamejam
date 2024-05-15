//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""77bfd252-0952-406a-9b68-a1b6e1a22e1a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b57fcd6f-e553-4dec-8a15-f9514d215aec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""2b776675-2ea2-4090-abbb-bc0623377a6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""4e536629-f0d5-4335-8fc8-4b77d5de2b7d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e617d592-4dff-4d1a-af46-1debd803cf33"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0f389767-1e9f-4cca-bc54-06df8833c334"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5fea4309-57d8-49d3-b7bd-d2fd408e1d32"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""046261c3-4a89-4662-85a1-05877bdbe3f1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f41460b3-973e-4dec-ac79-1472afaebc6d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c9422a1-5cc3-41f5-8673-7ea6fcd02a24"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2da71508-7159-4636-8581-2904466f7ca6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8d3bfc09-2274-45ee-99d6-14f5ab879985"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Console"",
                    ""id"": ""22dc9fbc-692a-4bb9-86b6-ef30e94368df"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9bf9e062-b4b1-4444-ad9f-16caf5c237ab"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4f59e3c7-678a-4cf5-b376-f38c472cd613"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b71c2f7-044f-4fdf-9c04-64f8e6288903"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fa38c7be-06f8-4eff-a308-d249a5f9cdbb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7c19db02-3cbc-49c7-b4c9-bd5a8fd3c331"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraMovement"",
            ""id"": ""bfd2a599-3f71-4264-b339-7fbf5d5a9e68"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""Value"",
                    ""id"": ""e1258243-d0f1-4897-89f8-610aebb5349e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""Value"",
                    ""id"": ""949d0f49-4906-4a9e-a146-04f852700c26"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""850de14a-bbe1-4716-a34e-538086e4ace3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fb57c1a-e9df-4052-8fa5-222b3cee8b6c"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""bfbde456-6188-4afb-b3c3-62c410e321cc"",
            ""actions"": [
                {
                    ""name"": ""ButtonPush"",
                    ""type"": ""Button"",
                    ""id"": ""ea4adebf-4d76-442b-9ec6-2605fef39357"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseScrollY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""19c89bcd-abbb-4bac-ae4a-1b32eb1fddd6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EscapePush"",
                    ""type"": ""Button"",
                    ""id"": ""581fa9ac-8b45-42d8-953e-4218878687d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QButtonPush"",
                    ""type"": ""Button"",
                    ""id"": ""e7d22682-278c-4fa0-b2d7-bee8a58fd5bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowButtonPush"",
                    ""type"": ""Button"",
                    ""id"": ""2bb69495-e45d-4d54-a405-c95bbbe65c33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""066ec31c-aef5-47bc-bc6c-bf5234fab78e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonPush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2eb0843-d167-4137-938e-0bd6acaa35fd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonPush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15ee7635-00c1-4f3d-8abe-999dc6b3ef78"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScrollY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c613cdf7-4e51-49b5-b411-f23291b1853b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapePush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""508df2c6-7234-498e-b097-2da0d99e82cb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QButtonPush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90426bdd-4583-4745-95be-efbd6d1f38f1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowButtonPush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MiniLockGame"",
            ""id"": ""0688f912-13d6-408f-94dd-69f34f66cba6"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""b39170db-4cbc-4e8e-b7ef-3699b087af60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3669aed-369c-4137-ac0d-f389a7599298"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
        // CameraMovement
        m_CameraMovement = asset.FindActionMap("CameraMovement", throwIfNotFound: true);
        m_CameraMovement_MouseX = m_CameraMovement.FindAction("MouseX", throwIfNotFound: true);
        m_CameraMovement_MouseY = m_CameraMovement.FindAction("MouseY", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_ButtonPush = m_Interaction.FindAction("ButtonPush", throwIfNotFound: true);
        m_Interaction_MouseScrollY = m_Interaction.FindAction("MouseScrollY", throwIfNotFound: true);
        m_Interaction_EscapePush = m_Interaction.FindAction("EscapePush", throwIfNotFound: true);
        m_Interaction_QButtonPush = m_Interaction.FindAction("QButtonPush", throwIfNotFound: true);
        m_Interaction_ThrowButtonPush = m_Interaction.FindAction("ThrowButtonPush", throwIfNotFound: true);
        // MiniLockGame
        m_MiniLockGame = asset.FindActionMap("MiniLockGame", throwIfNotFound: true);
        m_MiniLockGame_Newaction = m_MiniLockGame.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Crouch;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // CameraMovement
    private readonly InputActionMap m_CameraMovement;
    private List<ICameraMovementActions> m_CameraMovementActionsCallbackInterfaces = new List<ICameraMovementActions>();
    private readonly InputAction m_CameraMovement_MouseX;
    private readonly InputAction m_CameraMovement_MouseY;
    public struct CameraMovementActions
    {
        private @PlayerInput m_Wrapper;
        public CameraMovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_CameraMovement_MouseX;
        public InputAction @MouseY => m_Wrapper.m_CameraMovement_MouseY;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void AddCallbacks(ICameraMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Add(instance);
            @MouseX.started += instance.OnMouseX;
            @MouseX.performed += instance.OnMouseX;
            @MouseX.canceled += instance.OnMouseX;
            @MouseY.started += instance.OnMouseY;
            @MouseY.performed += instance.OnMouseY;
            @MouseY.canceled += instance.OnMouseY;
        }

        private void UnregisterCallbacks(ICameraMovementActions instance)
        {
            @MouseX.started -= instance.OnMouseX;
            @MouseX.performed -= instance.OnMouseX;
            @MouseX.canceled -= instance.OnMouseX;
            @MouseY.started -= instance.OnMouseY;
            @MouseY.performed -= instance.OnMouseY;
            @MouseY.canceled -= instance.OnMouseY;
        }

        public void RemoveCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private List<IInteractionActions> m_InteractionActionsCallbackInterfaces = new List<IInteractionActions>();
    private readonly InputAction m_Interaction_ButtonPush;
    private readonly InputAction m_Interaction_MouseScrollY;
    private readonly InputAction m_Interaction_EscapePush;
    private readonly InputAction m_Interaction_QButtonPush;
    private readonly InputAction m_Interaction_ThrowButtonPush;
    public struct InteractionActions
    {
        private @PlayerInput m_Wrapper;
        public InteractionActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonPush => m_Wrapper.m_Interaction_ButtonPush;
        public InputAction @MouseScrollY => m_Wrapper.m_Interaction_MouseScrollY;
        public InputAction @EscapePush => m_Wrapper.m_Interaction_EscapePush;
        public InputAction @QButtonPush => m_Wrapper.m_Interaction_QButtonPush;
        public InputAction @ThrowButtonPush => m_Wrapper.m_Interaction_ThrowButtonPush;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void AddCallbacks(IInteractionActions instance)
        {
            if (instance == null || m_Wrapper.m_InteractionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InteractionActionsCallbackInterfaces.Add(instance);
            @ButtonPush.started += instance.OnButtonPush;
            @ButtonPush.performed += instance.OnButtonPush;
            @ButtonPush.canceled += instance.OnButtonPush;
            @MouseScrollY.started += instance.OnMouseScrollY;
            @MouseScrollY.performed += instance.OnMouseScrollY;
            @MouseScrollY.canceled += instance.OnMouseScrollY;
            @EscapePush.started += instance.OnEscapePush;
            @EscapePush.performed += instance.OnEscapePush;
            @EscapePush.canceled += instance.OnEscapePush;
            @QButtonPush.started += instance.OnQButtonPush;
            @QButtonPush.performed += instance.OnQButtonPush;
            @QButtonPush.canceled += instance.OnQButtonPush;
            @ThrowButtonPush.started += instance.OnThrowButtonPush;
            @ThrowButtonPush.performed += instance.OnThrowButtonPush;
            @ThrowButtonPush.canceled += instance.OnThrowButtonPush;
        }

        private void UnregisterCallbacks(IInteractionActions instance)
        {
            @ButtonPush.started -= instance.OnButtonPush;
            @ButtonPush.performed -= instance.OnButtonPush;
            @ButtonPush.canceled -= instance.OnButtonPush;
            @MouseScrollY.started -= instance.OnMouseScrollY;
            @MouseScrollY.performed -= instance.OnMouseScrollY;
            @MouseScrollY.canceled -= instance.OnMouseScrollY;
            @EscapePush.started -= instance.OnEscapePush;
            @EscapePush.performed -= instance.OnEscapePush;
            @EscapePush.canceled -= instance.OnEscapePush;
            @QButtonPush.started -= instance.OnQButtonPush;
            @QButtonPush.performed -= instance.OnQButtonPush;
            @QButtonPush.canceled -= instance.OnQButtonPush;
            @ThrowButtonPush.started -= instance.OnThrowButtonPush;
            @ThrowButtonPush.performed -= instance.OnThrowButtonPush;
            @ThrowButtonPush.canceled -= instance.OnThrowButtonPush;
        }

        public void RemoveCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInteractionActions instance)
        {
            foreach (var item in m_Wrapper.m_InteractionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InteractionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);

    // MiniLockGame
    private readonly InputActionMap m_MiniLockGame;
    private List<IMiniLockGameActions> m_MiniLockGameActionsCallbackInterfaces = new List<IMiniLockGameActions>();
    private readonly InputAction m_MiniLockGame_Newaction;
    public struct MiniLockGameActions
    {
        private @PlayerInput m_Wrapper;
        public MiniLockGameActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MiniLockGame_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MiniLockGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiniLockGameActions set) { return set.Get(); }
        public void AddCallbacks(IMiniLockGameActions instance)
        {
            if (instance == null || m_Wrapper.m_MiniLockGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MiniLockGameActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IMiniLockGameActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IMiniLockGameActions instance)
        {
            if (m_Wrapper.m_MiniLockGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMiniLockGameActions instance)
        {
            foreach (var item in m_Wrapper.m_MiniLockGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MiniLockGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MiniLockGameActions @MiniLockGame => new MiniLockGameActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface ICameraMovementActions
    {
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnButtonPush(InputAction.CallbackContext context);
        void OnMouseScrollY(InputAction.CallbackContext context);
        void OnEscapePush(InputAction.CallbackContext context);
        void OnQButtonPush(InputAction.CallbackContext context);
        void OnThrowButtonPush(InputAction.CallbackContext context);
    }
    public interface IMiniLockGameActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
