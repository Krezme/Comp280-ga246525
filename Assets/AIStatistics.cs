using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIDefaultStatistics{
    public float health = 100;
    public float stamina = 100;
    public float energy = 100;
}

[System.Serializable]
public class AICurrentStatistics{
    public float health;
    public float stamina;
    public float energy;
}

[System.Serializable]
public class AITresholds{
    public float tiredness;
}

public class AIStatistics : MonoBehaviour
{
    public AIDefaultStatistics defaultStatistics;

    public AICurrentStatistics currentStatistics;

    public AITresholds aiTresholds;

    public float passiveExhaustionSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentStatistics.health = defaultStatistics.health;
        currentStatistics.stamina = defaultStatistics.stamina;
        currentStatistics.energy = defaultStatistics.energy;
    }

    // Update is called once per frame
    void Update()
    {
        SpendEnergy(Time.deltaTime * passiveExhaustionSpeed);
    }

    public void TakeDamage (float health) {
        currentStatistics.health -= health;
        if (currentStatistics.health < 0) {
            currentStatistics.health = 0;
        }
    }

    public void SpendStamina (float stamina) {
        currentStatistics.stamina -= stamina;
    }

    public void SpendEnergy (float energy) {
        currentStatistics.energy -= energy;
        if (currentStatistics.energy < 0) {
            currentStatistics.energy = 0;
        }
    }
}
