using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFollowArmEvents : MonoBehaviour
{

    public GameObject stopFollowArm;
    public AICommands aICommands;
    public Animator stopFollowArmAnimator;

    /// <summary>
    /// Stopping the arm from waving
    /// </summary>
    public void StopStopFollowWaving () {
        stopFollowArmAnimator.SetBool("isStopFollowWaving", false);
        stopFollowArm.gameObject.SetActive(false);
        aICommands.isStopFollowWaving = false;
    }
}
