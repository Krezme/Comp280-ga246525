using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;


//This action node is used to inisiate the campfire recharge branch
public class FireLowStrenght : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Checking for the campfire's strenght
        if (context.restSpotsScript.campFireStrenght.currentStrenght <= context.restSpotsScript.campFireStrenght.treshold) {
            blackboard.moveToPosition = context.restSpotsScript.campFireStrenght.getWoodSpot.transform.position; //Setting the next position to move to
            context.aiStatistics.isGatheringWood = true;
            context.aiStatistics.isLoadingFire = true;
            return State.Success;
        }
        return State.Failure;
    }
}
