using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationOfCopy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = transform.forward * 10f;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));
        }*/

        Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(origin, out hit, 10f)) {
            InstantiateLocationOfCopy(origin);
        }
        else {
            InstantiateLocationOfCopy(origin);
        }
        
    }

    void InstantiateLocationOfCopy (Ray origin) {
        if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = transform.position + origin.direction * 10f;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));   
            Debug.Log(origin.direction);
        }
    }
}
