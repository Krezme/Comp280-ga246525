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
            context.agent.updateRotation = false;
            Vector3 lookPos = context.restSpotsScript.campFire.transform.position - context.transform.position;
            lookPos.y = 0;
            context.transform.rotation = Quaternion.LookRotation(lookPos);
            return State.Running;
        }
        context.animator.SetBool("Tired", false);
        context.agent.updateRotation = true;
        return State.Success;
    }
}
