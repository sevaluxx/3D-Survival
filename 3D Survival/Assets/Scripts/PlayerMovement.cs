using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the Player Movement script.
This script Handles all player movement. 
Running, Jumping, sliding, etc.
Removing/Disabling this script will not break anything.
Requires PlayerAnimator component.
*/

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private CharacterController _characterController;

    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _rotationSpeed = 150.0f;
    [SerializeField]
    private float _Gravity = 9.81f;
    private Vector3 _moveDirection = Vector3.zero;

    private void Start() {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update() { MovePlayer(); }

    private void MovePlayer(){
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Optional: Prevent walking backwards
        if( verticalInput < 0){
            verticalInput = 0;
        }

        transform.Rotate(0, horizontalInput * _rotationSpeed * Time.deltaTime, 0);

        if(_characterController.isGrounded){
            _moveDirection = Vector3.forward * verticalInput;
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;

            // Send to animator
            _playerAnimator.isMoving = (verticalInput > 0 || (horizontalInput != 0));
            _playerAnimator.isWaving = (Input.GetButtonDown("Jump"));

        }   
        
        _moveDirection.y -= _Gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
   
    }
}
