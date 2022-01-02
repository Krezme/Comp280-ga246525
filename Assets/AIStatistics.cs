using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AIDefaultStatistics{
    public float health = 100;
    public float stamina = 100; //Not used
    public float energy = 100;
}

[System.Serializable]
public class AICurrentStatistics{
    public float health;
    public float stamina; //Not used
    public float energy;
}

[System.Serializable]
public class AITresholds{
    public float tiredness;
}

public class AIStatistics : MonoBehaviour
{
    
    public BehaviourTreeRunner behaviourTreeRunner; // The BehaviourTreeRunner script attached to this AI character
    
    public AIDefaultStatistics defaultStatistics; // a reference to the AIDefaultStatistics 

    public AICurrentStatistics currentStatistics; // a reference to the AICurrentStatistics 

    public AITresholds aiTresholds; // a reference to the AITresholds 


    public float passiveExhaustionSpeed; // speed of how fast the AI tiers out
    public float campFireRestSpeed; // How fast the AI regains energy when resting
    public bool isResting; // if the AI is resting currently
    public bool isGatheringWood; // if the AI needs to gather wood or is gathering it currently
    public bool isLoadingFire; // can load the fire 

    // Start is called before the first frame update
    void Start()
    {
        currentStatistics.health = defaultStatistics.health;
        currentStatistics.stamina = defaultStatistics.stamina;
        currentStatistics.energy = defaultStatistics.energy;
    }

    /// <summary>
    /// Constantly spending energy
    /// </summary>
    void Update()
    {
        behaviourTreeRunner.context.animator.SetFloat("Speed", behaviourTreeRunner.context.agent.velocity.magnitude);
        if (!isResting) {
            SpendEnergy(Time.deltaTime * passiveExhaustionSpeed);
        }
    }

    /// <summary>
    /// NOT USED
    /// </summary>
    /// <param name="health"></param>
    public void TakeDamage (float health) {
        currentStatistics.health -= health;
        if (currentStatistics.health < 0) {
            currentStatistics.health = 0;
        }
    }

    /// <summary>
    /// NOT USED
    /// </summary>
    /// <param name="stamina"></param>
    public void SpendStamina (float stamina) {
        currentStatistics.stamina -= stamina;
    }

    /// <summary>
    /// Spending energy and capping it to min 0
    /// </summary>
    /// <param name="energy"></param>
    public void SpendEnergy (float energy) {
        currentStatistics.energy -= energy;
        if (currentStatistics.energy <= 0) {
            currentStatistics.energy = 0;
        }
    }

    /// <summary>
    /// Filling up the enery when called (currently only called when resting at a camp fire)
    /// </summary>
    public void CampFireResting() {
        currentStatistics.energy += Time.deltaTime * campFireRestSpeed;
        if (currentStatistics.energy >= defaultStatistics.energy) {
            currentStatistics.energy = defaultStatistics.energy;
        }
    }
}
