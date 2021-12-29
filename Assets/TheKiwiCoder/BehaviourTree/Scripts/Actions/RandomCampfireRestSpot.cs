using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomCampfireRestSpot : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.moveToPosition = context.restSpotsScript.campfireRestSpots[Random.Range(0, context.restSpotsScript.campfireRestSpots.Length)].transform.position;
        return State.Success;
    }
}
