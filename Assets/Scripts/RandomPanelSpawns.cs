using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using UnityEngine.UI;

public class RandomPanelSpawns : RandomPanelSpawnSyncBehavior
{

    public GameObject[] panels;

    //spawnpoints for the coloured panels
    private Transform[] spawnPoints;

    public int[] tilesInOrder;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {


# if UNITY_EDITOR
        spawnPoints = new Transform[this.transform.childCount];
        tilesInOrder = new int[spawnPoints.Length];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            spawnPoints[i] = this.transform.GetChild(i);
            int rnd = Random.Range(0, panels.Length);
            Instantiate(panels[rnd], spawnPoints[i]);
            tilesInOrder[i] = rnd;
        }
# endif
    }

# if !UNITY_EDITOR
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (networkObject.IsServer) {
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
    }
# endif

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PanelsOrderList(RpcArgs args)
    {
        /* string intListInStringFormat = 
        string[] tempStringArr = intListInStringFormat.Split(char.Parse(","));
        tilesInOrder = new int[tempStringArr.Length];
        for (int i = 0; i < tempStringArr.Length; i++) {
            tilesInOrder[i] = int.Parse(tempStringArr[i]);
        }
        foreach (int i in tilesInOrder) {
            intListInStringFormat += i + ",";
        }
        intListInStringFormat += " -------------------"; */
        text.text = args.GetAt<string>(0);
    }
}
