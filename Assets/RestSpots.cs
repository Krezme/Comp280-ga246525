using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestSpots : MonoBehaviour
{
    public GameObject[] campfireRestSpots;
    // Start is called before the first frame update
    void Start()
    {
        campfireRestSpots = GameObject.FindGameObjectsWithTag("CampFireRestStop");
    }
}
