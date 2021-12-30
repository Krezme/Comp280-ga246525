using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookSinglePlayer : MonoBehaviour
{
    
    public float mouseSensitivity = 1000f;

    float xRotation = 0f;

    private GameObject playerGameObject;

    void Start () {
        //Cursor.lockState = CursorLockMode.Locked;
        playerGameObject = transform.parent.gameObject;
    }

    void Update () {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerGameObject.transform.Rotate(Vector3.up, mouseX);
    }
}
