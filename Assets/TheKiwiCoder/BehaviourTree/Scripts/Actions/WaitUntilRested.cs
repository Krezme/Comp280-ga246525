using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaitUntilRested : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.aiStatistics.currentStatistics.energy < context.aiStatistics.defaultStatistics.energy) {
            context.aiStatistics.CampFireResting();
            return State.Running;
        }
        return State.Success;
    }
}
