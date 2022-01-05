using UnityEngine;
using UnityEngine.InputSystem;
using BetterDebug;
using AutoGenerated.Input;

namespace GameManagement.Input
{
    public class InputHandler : MonoBehaviour
    {
        private void Awake()
        {
            PlayerInputActions actions = new PlayerInputActions();

            actions.PlayerActions.Movement.performed += PlayerMove;
            actions.PlayerActions.Jump.performed += PlayerJump;

            EnablePlayerActionMap(actions);
        }

        private void EnablePlayerActionMap(PlayerInputActions actions)
        {
            actions.PlayerActions.Enable();
        }

        private void PlayerMove(InputAction.CallbackContext context)
        {
            AdvancedDebug.Log("Input action: " + context);
        }

        private void PlayerJump(InputAction.CallbackContext context)
        {
            AdvancedDebug.Log("Input action: " + context);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}