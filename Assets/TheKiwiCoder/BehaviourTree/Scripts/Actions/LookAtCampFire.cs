using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class LookAtCampFire : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Constantly looking at the campfire
        if (context.aiStatistics.isLoadingFire) {
            context.agent.updateRotation = false;
            Vector3 lookPos = context.restSpotsScript.campFire.transform.position - context.transform.position;
            lookPos.y = 0;
            context.transform.rotation = Quaternion.LookRotation(lookPos);
            return State.Running;
        }
        context.agent.updateRotation = true;
        return State.Success;
    }
}
