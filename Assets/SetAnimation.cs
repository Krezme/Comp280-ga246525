using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SetAnimation : ActionNode
{
    public string animationToPlay;
    public float floatValue;
    public int intValue;
    public bool stateValue;

    [Header("")]
    public bool floatAnimation;
    public bool intAnimation;
    public bool boolAnimation;
    public bool triggerAnimation;

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
        return State.Success;
    }
}
