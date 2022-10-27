using System;
using System.Collections;
using System.Collections.Generic;
using Sirhot.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sirhot.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform _playerTransform;
        private Rigidbody _playerRb;
        private PlayerInputActions _playerInputActions;

        private void Awake()
        {
            _playerTransform = transform;
            _playerRb = GetComponent<Rigidbody>();

            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Jump.performed += Jump;
        }

        private void Start()
        {
            //ON START EVENT ASSIGNMENTS
            EventManager.onUpdate+=Move;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            _playerRb.AddForce(Vector3.up * 10,ForceMode.Impulse);
        }

        private void Move()
        {
            Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
            float speed = 5f;
            _playerTransform.position += new Vector3(inputVector.x, 0, inputVector.y) * (speed * Time.deltaTime);
        }
    }

}
