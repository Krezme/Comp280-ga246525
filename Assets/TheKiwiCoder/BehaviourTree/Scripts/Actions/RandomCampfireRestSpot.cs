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

    /// <summary>
    /// Chosing a random spot at the camp fire for the AI to go to
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate() {
        blackboard.moveToPosition = context.restSpotsScript.campfireRestSpots[Random.Range(0, context.restSpotsScript.campfireRestSpots.Length)].transform.position;
        return State.Success;
    }
}
