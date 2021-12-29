using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SetBoolAnimation : ActionNode
{
    public string animationToPlay;

    public bool animationState;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.animator.SetBool(animationToPlay, animationState);
        return State.Success;
    }
}
