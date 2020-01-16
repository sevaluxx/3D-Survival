using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is a Camera follow / Orbit script.
Removing/Disabling this script will not break anything.
*/
public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    [Range(0.01f, 1.0f)]
    public float smoothing = 0.5f;
    public bool _lookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 3f;


    private Vector3 _cameraOffset;

    private void Start() {
        _cameraOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate() {
        if(RotateAroundPlayer){
            Quaternion cameraTurnAngle = 
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            
            _cameraOffset = cameraTurnAngle * _cameraOffset;
        }

        Vector3 newPosition = playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothing);
    
        if(_lookAtPlayer || RotateAroundPlayer){
            transform.LookAt(playerTransform);
        }
    }
}
