using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsGathering : ActionNode
{
    public bool gatheringState;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.aiStatistics.isGatheringWood = gatheringState;
        return State.Success;
    }
}
