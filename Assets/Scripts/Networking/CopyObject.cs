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

    string[] tagsLeft = new string[4] {"BlueLeft", "RedLeft", "OrangeLeft", "GreenLeft"};
    string[] tagsRight = new string[4] {"BlueRight", "RedRight", "OrangeRight", "GreenRight"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Copies the vertices and tris of the object
    /// </summary>
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
                CopyData.instance.selectedMaterial = SetCopiedMaterial(hit.transform.gameObject);
                CopyData.instance.itemCopied = true;
                Debug.Log("Game Object: " + hit.transform.gameObject.name + " is coppied.");
            }
        }
    }

    int SetCopiedMaterial (GameObject gameObject) {
        for (int i = 0; i < tagsLeft.Length; i++) {
            if (gameObject.tag == tagsLeft[i]) {
                return i;
            }
            if (gameObject.tag == tagsRight[i]) {
                return i; 
            }
        }
        return 0;
    }
}
