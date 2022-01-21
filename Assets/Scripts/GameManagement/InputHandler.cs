using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using AutoGenerated.Input;

namespace GameManagement.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private Color baseControllerColor;

        private PlayerInputActions actions;

        private void Awake()
        {
            var gamepad = (DualShockGamepad)Gamepad.all[0];
            gamepad.SetLightBarColor(baseControllerColor);

            actions = new PlayerInputActions();

            actions.PlayerActions.Jump.started += Jump;
            actions.PlayerActions.Dash.started += Dash;

            EnablePlayerActionMap(actions);
        }

        private void EnablePlayerActionMap(PlayerInputActions actions) { actions.PlayerActions.Enable(); }

        private void Update()
        {
            Vector2 movementVector = actions.PlayerActions.Movement.ReadValue<Vector2>();
            player.PlayerMove(movementVector);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            player.PlayerJump();
        }

        private void Dash(InputAction.CallbackContext context)
        {
            player.PlayerDash();
        }
    }
}