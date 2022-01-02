using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICommands : MonoBehaviour
{
    public GameObject waveArm;
    public Animator waveArmAnimator;
    public bool isWaving;

    public GameObject followArm;
    public Animator followArmAnimator;
    public bool isFollowWaving;

    public GameObject stopFollowArm;
    public Animator stopFollowArmAninator;
    public bool isStopFollowWaving;

    /// <summary>
    /// Checking for the input by the player 1, 2 and 3 on the key board
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayAnimation(waveArm, waveArmAnimator, "isWaving");
            isWaving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            PlayAnimation(followArm, followArmAnimator, "isFollowWaving");
            isFollowWaving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            PlayAnimation(stopFollowArm, stopFollowArmAninator, "isStopFollowWaving");
            isStopFollowWaving = true;
        }
    }

    /// <summary>
    /// playing the needed animation
    /// </summary>
    /// <param name="arm">arm to animate</param>
    /// <param name="armAnim">animator to use</param>
    /// <param name="animationToPlay">animation to activate</param>
    void PlayAnimation (GameObject arm, Animator armAnim, string animationToPlay) {
        arm.gameObject.SetActive(true);
        armAnim.SetBool(animationToPlay, true);
    }
}
