using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class RandomPanelSpawns : RandomPanelSpawnSyncBehavior
{

    public GameObject[] panels;

    //spawnpoints for the coloured panels
    private Transform[] spawnPoints;

    public int[] tilesInOrder;

    // Start is called before the first frame update
    void Start()
    {

# if !UNITY_EDITOR
        if (networkObject == null)
        {
            return;
        }

        if (!networkObject.IsOwner) {
            return;
        }
# endif
        spawnPoints = new Transform[this.transform.childCount];
        tilesInOrder = new int[spawnPoints.Length];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            spawnPoints[i] = this.transform.GetChild(i);
            int rnd = Random.Range(0, panels.Length);
            Instantiate(panels[rnd], spawnPoints[i]);
            tilesInOrder[i] = rnd;
        }
        string intListInStringFormat = "";
        foreach (int i in tilesInOrder) {
            intListInStringFormat += i + ",";
        }
        networkObject.SendRpc(RPC_PANELS_ORDER_LIST, Receivers.AllBuffered, intListInStringFormat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PanelsOrderList(RpcArgs args)
    {
        string intListInStringFormat = args.GetAt<string>(0);
        string[] tempStringArr = intListInStringFormat.Split(char.Parse(","));
        tilesInOrder = new int[tempStringArr.Length];
        for (int i = 0; i < tempStringArr.Length; i++) {
            tilesInOrder[i] = int.Parse(tempStringArr[i]);
        }
        foreach (int i in tilesInOrder) {
            intListInStringFormat += i + ",";
        }
        intListInStringFormat += " -------------------";
        throw new System.NullReferenceException(intListInStringFormat);
    }
}
