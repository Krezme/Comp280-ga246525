using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    [SerializeField] LayerMask copyableObject;
    [SerializeField] int maxDistance = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetButtonDown("Fire2") && Physics.Raycast(origin, out hit, maxDistance, copyableObject.GetHashCode())) {
            
            CopyData.instance.copiedGameObjectVertices = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.vertices;
            CopyData.instance.copiedGameObjectTris = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.triangles;
            CopyData.instance.itemCopied = true;
            Debug.Log("Game Object: " + hit.transform.gameObject.name + " is coppied.");
            Debug.Log("vertices: " + CopyData.instance.copiedGameObjectVertices);
            Debug.Log("Tris: " + CopyData.instance.copiedGameObjectTris);

        }
    }
}
