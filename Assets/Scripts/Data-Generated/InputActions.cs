//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/Data/Input/InputActions.inputactions
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

namespace AutoGenerated.Input
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""e7585dc3-baf8-43f3-a6d6-53a400454ed0"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""683a7dbb-351b-4835-8216-be944fea67e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2f6c7555-5cb8-41c0-8135-4b142e088355"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f9e58af-5a14-478f-a7e3-55144aff587c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9d6c1fb4-20ef-42f8-9570-cf1748787c6d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a1bbf9a-2c47-43af-930a-ab27a4744afd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac77aae5-dbd2-42a8-99f2-a1972504e18c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""433545cc-a2b9-4e62-a7f4-e2e5f75c6ffe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""515b1994-b5e1-4650-bc0d-7455eb70c4af"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerActions
            m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
            m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
            m_PlayerActions_Movement = m_PlayerActions.FindAction("Movement", throwIfNotFound: true);
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

        // PlayerActions
        private readonly InputActionMap m_PlayerActions;
        private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
        private readonly InputAction m_PlayerActions_Jump;
        private readonly InputAction m_PlayerActions_Movement;
        public struct PlayerActionsActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
            public InputAction @Movement => m_Wrapper.m_PlayerActions_Movement;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActionsActions instance)
            {
                if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Movement.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
        public interface IPlayerActionsActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
