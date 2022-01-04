using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PasteObject : MonoBehaviour
{

    /// <summary>
    /// pastes the data from the copied game object
    /// </summary>
    void Start()
    {
        MeshFilter meshFilter;
        meshFilter = this.gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh.vertices = CopyData.instance.copiedGameObjectVertices;
        meshFilter.mesh.triangles = CopyData.instance.copiedGameObjectTris;
        meshFilter.mesh.RecalculateNormals();
        gameObject.GetComponent<Renderer>().material = CopyData.instance.copyMaterials[CopyData.instance.selectedMaterial];
    }
}
