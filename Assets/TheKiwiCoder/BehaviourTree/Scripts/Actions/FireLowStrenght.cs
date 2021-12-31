using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FireLowStrenght : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.restSpotsScript.campFireStrenght.currentStrenght <= context.restSpotsScript.campFireStrenght.treshold) {
            blackboard.moveToPosition = context.restSpotsScript.campFireStrenght.getWoodSpot.transform.position;
            context.aiStatistics.isGatheringWood = true;
            context.aiStatistics.isLoadingFire = true;
            return State.Success;
        }
        return State.Failure;
    }
}
