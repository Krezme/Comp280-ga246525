using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking.Generated;

public class LocationOfCopy : LocationOfCopyBehavior
{

    public float maxDistanceOfCopy = 10f;
    /*public float minDistanceOfCopy = 2f;
    public float currentDistanceOfCopy; */
    public Vector3 pointerOffset;
    public Camera playerCam;
    [SerializeField] LayerMask pastableLayer;

    public GameObject raybitch;

    [SerializeField]LayerMask layersToCheck;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsOwner) {
            this.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        raybitch.transform.SetParent(null);
    }

    /// <summary>
    /// Controls the position of the pointer object
    /// </summary>
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = transform.forward * 10f;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));
        }*/
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray origin = playerCam.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;
        
        layersToCheck.value = CopyData.instance.randomPanelLayerToPasteOn.value + pastableLayer.value;

        if (Physics.Raycast(origin, out hit, maxDistanceOfCopy, layersToCheck)) {
            
            InstantiateLocationOfCopy(origin, hit);
            raybitch.transform.position = hit.point;
        }
        else {
            
            //InstantiateLocationOfCopy(origin, hit);
            raybitch.transform.localPosition = (transform.position + pointerOffset) + origin.direction * maxDistanceOfCopy;
        }
    }

    /// <summary>
    /// Calculates if the pointer gO can be spawned on the pointed object and instantiates the copied game object
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="hit"></param>
    void InstantiateLocationOfCopy (Ray origin, RaycastHit hit) {
        if  (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied && (hit.point != null && hit.transform)) { /// (hit.point != null) for "Drawing"
            //Instantiate(CopyData.instance.pasteObjectCopy, hit.point, Quaternion.Euler(0,0,0));
            Vector3 positionOffset = Vector3.zero;
            if (CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("BlueLeft") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("RedLeft") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("OrangeLeft") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("GreenLeft")) {
                positionOffset = new Vector3(0.5f, 0, 0);
            }
            else if (CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("BlueRight") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("RedRight") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("OrangeRight") ||
            CopyData.instance.randomPanelLayerToPasteOn.value == 1<< LayerMask.NameToLayer("GreenRight")) {
                positionOffset = new Vector3(-0.5f, 0, 0);
            }
            NetworkManager.Instance.InstantiateSyncPastedGameObject(0,new Vector3(hit.transform.gameObject.transform.position.x + positionOffset.x, 
            hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z),Quaternion.Euler(0,0,0));
        }
        /* else if (Input.GetButtonDown("Fire1") && CopyData.instance.itemCopied) {
            Vector3 spawnPoint = (transform.position + pointerOffset) + origin.direction * maxDistanceOfCopy;
            Instantiate(CopyData.instance.pasteObjectCopy, spawnPoint, Quaternion.Euler(0,0,0));   
            
            Debug.Log(origin.direction);
        } */

    }
}
