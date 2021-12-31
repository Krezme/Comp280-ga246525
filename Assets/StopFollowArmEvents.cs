using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFollowArmEvents : MonoBehaviour
{

    public GameObject stopFollowArm;
    public AICommands aICommands;
    public Animator stopFollowArmAnimator;

    public void StopStopFollowWaving () {
        stopFollowArmAnimator.SetBool("isFollowWaving", false);
        stopFollowArm.gameObject.SetActive(false);
        aICommands.isStopFollowWaving = false;
    }
}
