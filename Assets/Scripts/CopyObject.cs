using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    [SerializeField] LayerMask copyableObject;

    [Header("CopyDistance")]
    [SerializeField] bool useCappedDistance = false;
    [SerializeField] float maxDistance = 1000f;
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxDistance = useCappedDistance ? maxDistance : Mathf.Infinity;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray origin = playerCam.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;
        
        if (Input.GetButtonDown("Fire2")) {
            Debug.Log("right click pressed");
        }

        if (Physics.Raycast(origin, out hit, maxDistance, copyableObject)) {
            if (Input.GetButtonDown("Fire2")) {
                Debug.Log("Copy");
                CopyData.instance.randomPanelLayerToPasteOn.value = 1<< LayerMask.NameToLayer(hit.transform.gameObject.tag);
                CopyData.instance.copiedGameObjectVertices = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.vertices;
                CopyData.instance.copiedGameObjectTris = hit.transform.gameObject.GetComponent<MeshFilter>().mesh.triangles;
                CopyData.instance.itemCopied = true;
                Debug.Log("Game Object: " + hit.transform.gameObject.name + " is coppied.");
            }
        }
    }
}
