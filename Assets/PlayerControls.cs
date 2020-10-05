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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""567eb0d9-b431-45fb-bdb8-05a001f16f1f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
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
    public struct PlayerShipActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerShipActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_PlayerShip_Fire;
        public InputAction @Exit => m_Wrapper.m_PlayerShip_Exit;
        public InputAction @AimMouse => m_Wrapper.m_PlayerShip_AimMouse;
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
            }
        }
    }
    public PlayerShipActions @PlayerShip => new PlayerShipActions(this);
    public interface IPlayerShipActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnAimMouse(InputAction.CallbackContext context);
    }
}
