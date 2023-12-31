using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsResting : ActionNode
{
    public bool restingState;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Changing the state depending on the in editor given sate
        context.aiStatistics.isResting = restingState;
        return State.Success;
    }
}
