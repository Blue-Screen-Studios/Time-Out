using UnityEngine;
using BetterDebug;
using System;

namespace GameManagement
{
    public class InputSystem : MonoBehaviour
    {
        public enum InputMode { Mobile, Console, PC };
        public InputMode targetInputDevice;
        public enum InputTrigger { Left, Right, Up, Down, Jump, LeftClick, RightClick, Exit, None };
        public InputTrigger activeInputTrigger;

        [HideInInspector] public bool showTouchControls;

        [SerializeField] private GameObject mobileControls;

        private void Start()
        {
            if(targetInputDevice == InputMode.Mobile)
            {
                //show mobile controls
            }
            else
            {
                //hide mobile controls
            }
        }
        
        private void Update()
        {
            activeInputTrigger = GetInput();
        }

        private InputTrigger GetInput()
        {
            switch (targetInputDevice)
            {
                case InputMode.PC:

                    float PCInput = Input.GetAxisRaw("Horizontal"); //Get horizontal axis without time distortion

                    //Compare axis against zero and return accordingly
                    if (PCInput > 0) { return InputTrigger.Right; }
                    if (PCInput < 0) { return InputTrigger.Left; }

                    //Check for key input
                    if (Input.GetKeyDown(KeyCode.Space)) { return InputTrigger.Up; }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftShift)) { return InputTrigger.Down; }

                    //Check for mouse input
                    if (Input.GetMouseButtonDown(0)) { return InputTrigger.LeftClick; }
                    if (Input.GetMouseButtonDown(1)) { return InputTrigger.RightClick; }

                    //Check for exit input
                    if (Input.GetKey(KeyCode.Escape)) { return InputTrigger.Exit; }

                    //Return no trigger if no input recieved in this frame
                    return InputTrigger.None;

                case InputMode.Console:

                    float consoleInput = Input.GetAxisRaw("Horizontal");

                    if (consoleInput > 0) { return InputTrigger.Right; }
                    if (consoleInput < 0) { return InputTrigger.Left; }

                    if (Input.GetButtonDown("Jump")) { return InputTrigger.Up; }
                    return InputTrigger.None;

                case InputMode.Mobile:

                    return InputTrigger.None;

                default:
                    AdvancedDebug.LogException(new NotImplementedException());
                    return InputTrigger.None;
            }
        }
    }
}
