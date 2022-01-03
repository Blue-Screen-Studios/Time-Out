using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class InputSystem : MonoBehaviour
    {
        private enum InputMode { Mobile, Console, PC };
        [SerializeField] InputMode targetInputDevice;

        struct Axis
        {
            private float _xAxis;
            private float _yAxis;

            public float xAxis { get { return _xAxis; } }
            public float yAxis { get { return _yAxis; } }
        }

        struct Triggers
        {
            private bool _escape;
            private bool _jump;
            private bool _dash;
            private bool _shoot;

            public bool escape { get { return _escape; } }
            public bool jump { get { return _jump; } }
            public bool dash { get { return _dash; } }
            public bool shoot { get { return _shoot; } }
        }

        private void Update()
        {
            
        }
    }
}
