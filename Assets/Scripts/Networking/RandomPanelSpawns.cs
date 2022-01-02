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
            for (int i = 0; i < tilesInOrder.Length; i++) {
                if (i < tilesInOrder.Length - 1){
                    intListInStringFormat += tilesInOrder[i] + ",";
                }
                else
                {
                    intListInStringFormat += tilesInOrder[i];
                }
            }
            networkObject.SendRpc(RPC_PANELS_ORDER_LIST, Receivers.AllBuffered, intListInStringFormat);
        }
    }
#endif

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void PanelsOrderList(RpcArgs args)
    {
# if !UNITY_EDITOR
        if (!networkObject.IsServer) {
            string intListInStringFormat = args.GetAt<string>(0);
            string[] tempStringArr = intListInStringFormat.Split(char.Parse(","));
            tilesInOrder = new int[tempStringArr.Length];
            spawnPoints = new Transform[this.transform.childCount];
            for (int i = 0; i < tempStringArr.Length; i++) {
                tilesInOrder[i] = int.Parse(tempStringArr[i]);
            }
            for (int i = 0; i < this.transform.childCount; i++)
            {
                spawnPoints[i] = this.transform.GetChild(i);
                Instantiate(panels[tilesInOrder[i]], spawnPoints[i]);
            }
        }
        return;
# endif
        throw new System.NotImplementedException();
    }
}
