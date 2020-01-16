using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
    This is the First Person Movement script.
    This script handles player movement for the 
    first person view. This script requires a 
    Character Controller component.
*/
[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float gravity = -9.81f;

    private Vector3 velocity;


    private void Start() { controller = GetComponent<CharacterController>(); }

    private void Update() {

        // Get Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move player
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * speed * Time.deltaTime);
        
        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
