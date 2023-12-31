using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class LookAtTree : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Looking at the tree when gathering wood
        if (context.aiStatistics.isGatheringWood) {
            context.agent.updateRotation = false;
            Vector3 lookPos = context.restSpotsScript.campFireStrenght.tree.transform.position - context.transform.position;
            lookPos.y = 0;
            context.transform.rotation = Quaternion.LookRotation(lookPos);
            return State.Running;
        }
        context.agent.updateRotation = true;
        return State.Success;
    }
}
