using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float viewLimit = 90f;

    // allow player to adjust in-game
    public float mouseSensitivity = 100f;
    
    private float xRotation = 0f;


    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        xRotation -= mouseY;

        // Prevent 360 vertical view
        xRotation = Mathf.Clamp(xRotation, -viewLimit, viewLimit);


        transform.localRotation = Quaternion.Euler(xRotation, 0f , 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
