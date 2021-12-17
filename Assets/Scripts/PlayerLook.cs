using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class PlayerLook : PlayerLookBehavior
{
    
    public float mouseSensitivity = 1000f;

    float xRotation = 0f;

    private GameObject playerGameObject;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        playerGameObject = transform.parent.gameObject;
        if (!networkObject.IsOwner) {
            transform.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }

    void Update () {

        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner) {
            transform.rotation = networkObject.rotation;
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerGameObject.transform.Rotate(Vector3.up, mouseX);

        networkObject.rotation = transform.rotation;
    }
}
