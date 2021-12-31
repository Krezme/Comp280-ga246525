using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArmEvents : MonoBehaviour
{

    public GameObject followArm;
    public AICommands aICommands;
    public Animator followArmAnimator;

    public void StopFollowWaving () {
        followArmAnimator.SetBool("isFollowWaving", false);
        followArm.gameObject.SetActive(false);
        aICommands.isFollowWaving = false;
    }
}
