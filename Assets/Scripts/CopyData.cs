using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyData : MonoBehaviour
{

    #region Singleton

    public static CopyData instance;

    void Awake () {
        if (instance != null) {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    #endregion
    
    [HideInInspector] public bool itemCopied = false;
    [HideInInspector] public Vector3[] copiedGameObjectVertices;
    [HideInInspector] public int[] copiedGameObjectTris;
    public LayerMask randomPanelLayerToPasteOn;

    public GameObject pasteObjectCopy;

    public Material[] copyMaterials;

    public int selectedMaterial;

}
