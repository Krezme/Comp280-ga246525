using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationOfCopy : MonoBehaviour
{

    public float maxDistanceOfCopy = 10f;
    /*public float minDistanceOfCopy = 2f;
    public float currentDistanceOfCopy; */
    public Vector3 pointerOffset;
    public Camera playerCam;

    public GameObject raybitch;

    // Start is called before the first frame update
    void Start()
    {
        raybitch.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = transform.forward * 10f;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));
        }*/
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray origin = playerCam.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;

        if (Physics.Raycast(origin, out hit, 10f)) {
            
            InstantiateLocationOfCopy(origin, hit);
            raybitch.transform.position = hit.point;
        }
        else {
            
            InstantiateLocationOfCopy(origin, hit);
            raybitch.transform.localPosition = (transform.position + pointerOffset) + origin.direction * 10f;
        }
        
    }

    void InstantiateLocationOfCopy (Ray origin, RaycastHit hit) {
        if  (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied && (hit.point != null && hit.transform)) { /// (hit.point != null) for "Drawing"
            Instantiate(CopyData.instance.pasteObjectCopy, hit.point, Quaternion.Euler(0,0,0));
            
        }
        else if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = (transform.position + pointerOffset) + origin.direction * maxDistanceOfCopy;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));   
            
            Debug.Log(origin.direction);
        }

    }
}
