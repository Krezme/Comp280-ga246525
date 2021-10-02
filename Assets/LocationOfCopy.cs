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
            InstantiateLocationOfCopy(origin, hit);
        }
        else {
            InstantiateLocationOfCopy(origin, hit);
        }
        
    }

    void InstantiateLocationOfCopy (Ray origin, RaycastHit hit) {
        if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied && (hit.point != null && hit.transform)) { /// (hit.point != null) for "Drawing"
            Instantiate(CopyData.instance.pasteObjectCopy, hit.point, Quaternion.Euler(0,0,0));
        }
        else if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = transform.position + origin.direction * 10f;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));   
            Debug.Log(origin.direction);
        }
    }
}
