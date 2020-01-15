using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    This script simply locks the cursor.
*/
public class LockCursor : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
