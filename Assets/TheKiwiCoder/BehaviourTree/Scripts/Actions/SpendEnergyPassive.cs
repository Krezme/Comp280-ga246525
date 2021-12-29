using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SpendEnergyPassive : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.aiStatistics.SpendEnergy(Time.deltaTime * context.aiStatistics.passiveExhaustionSpeed);
        if (context.aiStatistics.currentStatistics.energy <= 0) {
            return State.Success;
        }
        return State.Running;
    }
}
