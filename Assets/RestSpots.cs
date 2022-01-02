using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestSpots : MonoBehaviour
{
    public GameObject campFire; /// Campfire of the AI
    public CampFireStrenght campFireStrenght; // The CampFireStrenght script of the campfire
    public GameObject[] campfireRestSpots; // the rest spots that are connected to the campfire referenced
    // Start is called before the first frame update
    void Start()
    {
        campfireRestSpots = GameObject.FindGameObjectsWithTag("CampFireRestStop");// finding all of the rest spots of the camp fire
    }
}
