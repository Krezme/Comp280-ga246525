using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPanelSpawns : MonoBehaviour
{

    public GameObject[] panels;

    //spawnpoints for the coloured panels
    private Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Transform[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            spawnPoints[i] = this.transform.GetChild(i);
            int rnd = Random.Range(0, panels.Length);
            Instantiate(panels[rnd], spawnPoints[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
