using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    [SerializeField] LayerMask copyableObject;

    [Header("CopyDistance")]
    [SerializeField] bool useCappedDistance = false;
    [SerializeField] float maxDistance = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        maxDistance = useCappedDistance ? maxDistance : Mathf.Infinity;

        Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(origin, out hit, maxDistance, copyableObject.GetHashCode())) {
            if (Input.GetButtonDown("Fire2")) {
                CopyData.instance.copiedGameObjectVertices = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.vertices;
                CopyData.instance.copiedGameObjectTris = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.triangles;
                CopyData.instance.itemCopied = true;
                Debug.Log("Game Object: " + hit.transform.gameObject.name + " is coppied.");
            }
        }
    }
}
