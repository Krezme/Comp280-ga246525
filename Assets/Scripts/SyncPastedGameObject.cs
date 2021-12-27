using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class SyncPastedGameObject : SyncPastedGameObjectBehavior
{

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public PasteObject thisPasteObject;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (networkObject.IsOwner) {
            networkObject.SendRpc(RPC_PASTED_GAME_OBJECT, Receivers.AllBuffered, ConvertVerticesToString(meshFilter.mesh.vertices), ConvertTrisToString(meshFilter.mesh.triangles), meshRenderer.material.color);
        }
        else
        {
            thisPasteObject.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
# if !UNITY_EDITOR
        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner) {
            transform.rotation = networkObject.rotation;
            transform.position = networkObject.position;
            return;
        }


        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;

# endif
    }

    private string ConvertVerticesToString(Vector3[] vertices) {
        string verticesInStringFormat = "";
        for (int j = 0; j < vertices.Length; j++) {
            for (int i = 0; i < 3; i++) {
                switch (i){
                    case 0:
                        verticesInStringFormat += vertices[j].x + ",";
                        break;
                    case 1:
                        verticesInStringFormat += vertices[j].y + ",";
                        break;
                    case 2:
                        if (j < vertices.Length-1) {
                            verticesInStringFormat += vertices[j].z + "#";
                        }
                        else
                        {
                            verticesInStringFormat += vertices[j].z;
                        }
                        break;
                }
            }
        }
        return verticesInStringFormat;
    }

    private string ConvertTrisToString (int[] tris) {
        string trisInStringFormat = "";
        for (int i = 0; i < tris.Length; i++) {
            if (i < tris.Length - 1) {
                trisInStringFormat += tris[i] + ",";
            }
            else
            {
                trisInStringFormat += tris[i];
            }
        }
        return trisInStringFormat;
    }

    public override void PastedGameObject(RpcArgs args)
    {
        if (!networkObject.IsOwner) {
            meshFilter.mesh.vertices = ConvertStringToVertices(args.GetAt<string>(0));
            meshFilter.mesh.triangles = ConvertStringToTris(args.GetAt<string>(1));
            meshRenderer.material.color = args.GetAt<Color>(2);
            meshFilter.mesh.RecalculateNormals();
        }
    }

    private Vector3[] ConvertStringToVertices (string verticesInStringFormat) {
        string[] vetricesInStringArrayFormat = verticesInStringFormat.Split(char.Parse("#"));
        Vector3[] vertices = new Vector3[vetricesInStringArrayFormat.Length];
        for (int i = 0; i < vetricesInStringArrayFormat.Length; i++) {
            string[] vetricesInStringArrayFormatByIndex = vetricesInStringArrayFormat[i].Split(char.Parse(","));
            Vector3 vertice = new Vector3(float.Parse(vetricesInStringArrayFormatByIndex[0]), float.Parse(vetricesInStringArrayFormatByIndex[1]), float.Parse(vetricesInStringArrayFormatByIndex[2]));
            vertices[i] = vertice;
        }
        return vertices;
    }

    private int[] ConvertStringToTris (string trisInStringFormat) {
        string[] tempStringArr = trisInStringFormat.Split(char.Parse(","));
        int[] tris = new int[tempStringArr.Length];
        for (int i = 0; i < tris.Length; i++) { 
            tris[i] = int.Parse(tempStringArr[i]);
        }
        return tris;
    }
}
