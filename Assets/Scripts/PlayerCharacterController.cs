using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float speed;
    public float mouseSensativity = 100f;

    public Rigidbody rigidBody;
    public Transform playerTransform;
    public GameObject playerCamera;

    float inputY = 0f;

    public float maxAngle;
    public float minAngle;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensativity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensativity * Time.deltaTime;

        inputY -= mouseY;

        playerTransform.Rotate(Vector3.up * mouseX);

        playerCamera.transform.localRotation = Quaternion.Euler(inputY, 0f, 0f);
        
    }
}
