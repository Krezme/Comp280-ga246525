using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireStrenght : MonoBehaviour
{
    public GameObject tree;
    public GameObject getWoodSpot;
    public float maxStrenght;
    public float currentStrenght;
    public float weakensSpeed;
    public float treshold;
    // Start is called before the first frame update
    void Start()
    {
        FireStrenghtReset();
    }

    /// <summary>
    /// Constantly weakens the camp fire
    /// </summary>
    void Update()
    {
        FireStrenghtWeakens();
    }

    /// <summary>
    /// weakens the campt fire strenght over time 
    /// </summary>
    void FireStrenghtWeakens() {
        currentStrenght -= Time.deltaTime * weakensSpeed;
        if (currentStrenght < 0) {
            currentStrenght = 0;
        }
    }

    /// <summary>
    /// restarting the strenght of the campfire
    /// </summary>
    public void FireStrenghtReset() {
        currentStrenght = maxStrenght;
    }
}
