using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SetAnimation : ActionNode
{
    [Header("Type of value to set")]
    public bool useRandomAnim;
    public bool floatAnimation;
    public bool intAnimation;
    public bool boolAnimation;
    public bool triggerAnimation;
    
    [Header("Data depending on value type")]
    public string animationToPlay;
    public float floatValue;
    public int intValue;
    public bool stateValue;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (floatAnimation) {
            context.animator.SetFloat(animationToPlay, floatValue);
        }
        else if (intAnimation)
        {
            context.animator.SetInteger(animationToPlay, intValue);
        }
        else if (boolAnimation) {
            context.animator.SetBool(animationToPlay, stateValue);
        }
        else if (triggerAnimation) {
            context.animator.SetTrigger(animationToPlay);
        }
        else if (useRandomAnim) {
            context.animator.SetInteger("RandomAnim", blackboard.randomAnimInt);
        }
        return State.Success;
    }
}
