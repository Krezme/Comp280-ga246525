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

    // Update is called once per frame
    void Update()
    {
        FireStrenghtWeakens();
    }

    void FireStrenghtWeakens() {
        currentStrenght -= Time.deltaTime * weakensSpeed;
        if (currentStrenght < 0) {
            currentStrenght = 0;
        }
    }

    public void FireStrenghtReset() {
        currentStrenght = maxStrenght;
    }
}
