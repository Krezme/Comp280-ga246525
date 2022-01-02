using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveArmEvents : MonoBehaviour
{

    public GameObject waveArm;
    public AICommands aICommands;
    public Animator waveArmAnimator;

    /// <summary>
    /// Stopping the arm from waving 
    /// </summary>
    public void StopWaving () {
        waveArmAnimator.SetBool("isWaving", false);
        waveArm.gameObject.SetActive(false);
        aICommands.isWaving = false;
    }
}
