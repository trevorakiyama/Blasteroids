// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerShip"",
            ""id"": ""f2a9c60b-ef48-44f9-9217-d654fcd2a3f4"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a2c87f35-f963-4e76-ad66-9c1ea072eba4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""555d4bed-57aa-4c18-8861-be4e71ef9e1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimMouse"",
                    ""type"": ""Value"",
                    ""id"": ""ad4faa53-e0a2-4899-80fd-ff2501a02084"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""e0e84be6-0867-4e8c-a606-407ec5b2e45d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""4aeb65c8-82aa-456f-8f8e-e1904d5d6575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d8dab727-34ab-461b-8552-c56a2164b569"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""f971f293-1f41-4cc1-bdb2-6b2a4cd7a440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Button"",
                    ""id"": ""db8121c1-76a0-465b-be0e-bfa6a4457704"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2bc48349-84d8-46c7-b0fd-2b0e53eac977"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f06af485-98ff-48c9-85c9-b3a65650b998"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b067429a-aa03-4ad6-93c9-3e227306d5d7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9d82d98-3697-470d-9716-1fb75921ddbe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""177bfbdb-2226-439c-9052-18b103151d55"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3319e065-617a-492e-b8ef-ace8eb37ebb6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8d16a8c-dbcf-4d61-b6fd-e955341f7d17"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2341d3a8-6f66-4160-b7d7-8f9bddad3ed8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerShip
        m_PlayerShip = asset.FindActionMap("PlayerShip", throwIfNotFound: true);
        m_PlayerShip_Fire = m_PlayerShip.FindAction("Fire", throwIfNotFound: true);
        m_PlayerShip_Exit = m_PlayerShip.FindAction("Exit", throwIfNotFound: true);
        m_PlayerShip_AimMouse = m_PlayerShip.FindAction("AimMouse", throwIfNotFound: true);
        m_PlayerShip_MoveUp = m_PlayerShip.FindAction("MoveUp", throwIfNotFound: true);
        m_PlayerShip_MoveDown = m_PlayerShip.FindAction("MoveDown", throwIfNotFound: true);
        m_PlayerShip_MoveLeft = m_PlayerShip.FindAction("MoveLeft", throwIfNotFound: true);
        m_PlayerShip_MoveRight = m_PlayerShip.FindAction("MoveRight", throwIfNotFound: true);
        m_PlayerShip_Thrust = m_PlayerShip.FindAction("Thrust", throwIfNotFound: true);
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

    // PlayerShip
    private readonly InputActionMap m_PlayerShip;
    private IPlayerShipActions m_PlayerShipActionsCallbackInterface;
    private readonly InputAction m_PlayerShip_Fire;
    private readonly InputAction m_PlayerShip_Exit;
    private readonly InputAction m_PlayerShip_AimMouse;
    private readonly InputAction m_PlayerShip_MoveUp;
    private readonly InputAction m_PlayerShip_MoveDown;
    private readonly InputAction m_PlayerShip_MoveLeft;
    private readonly InputAction m_PlayerShip_MoveRight;
    private readonly InputAction m_PlayerShip_Thrust;
    public struct PlayerShipActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerShipActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_PlayerShip_Fire;
        public InputAction @Exit => m_Wrapper.m_PlayerShip_Exit;
        public InputAction @AimMouse => m_Wrapper.m_PlayerShip_AimMouse;
        public InputAction @MoveUp => m_Wrapper.m_PlayerShip_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_PlayerShip_MoveDown;
        public InputAction @MoveLeft => m_Wrapper.m_PlayerShip_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_PlayerShip_MoveRight;
        public InputAction @Thrust => m_Wrapper.m_PlayerShip_Thrust;
        public InputActionMap Get() { return m_Wrapper.m_PlayerShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerShipActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerShipActions instance)
        {
            if (m_Wrapper.m_PlayerShipActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
                @Exit.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnExit;
                @AimMouse.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnAimMouse;
                @AimMouse.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnAimMouse;
                @AimMouse.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnAimMouse;
                @MoveUp.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveDown;
                @MoveLeft.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMoveRight;
                @Thrust.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnThrust;
            }
            m_Wrapper.m_PlayerShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @AimMouse.started += instance.OnAimMouse;
                @AimMouse.performed += instance.OnAimMouse;
                @AimMouse.canceled += instance.OnAimMouse;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
            }
        }
    }
    public PlayerShipActions @PlayerShip => new PlayerShipActions(this);
    public interface IPlayerShipActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnAimMouse(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnThrust(InputAction.CallbackContext context);
    }
}
