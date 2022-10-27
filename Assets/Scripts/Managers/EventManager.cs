using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sirhot.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static event Action onUpdate;

        private void Update()
        {
            onUpdate?.Invoke();
        }
    }
}

