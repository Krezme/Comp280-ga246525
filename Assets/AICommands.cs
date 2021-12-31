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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    void PlayAnimation (GameObject arm, Animator armAnim, string animationToPlay) {
        arm.gameObject.SetActive(true);
        armAnim.SetBool(animationToPlay, true);
    }
}
