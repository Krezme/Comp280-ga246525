using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsTired : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.aiStatistics.currentStatistics.energy <= context.aiStatistics.aiTresholds.tiredness) {
            return State.Success;
        }
        return State.Failure;
    }
}
