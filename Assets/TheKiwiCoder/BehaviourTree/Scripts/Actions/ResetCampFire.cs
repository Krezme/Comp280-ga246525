using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ResetCampFire : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    /// <summary>
    /// Setting the campfire back to dofault strenght
    /// </summary>
    /// <returns></returns>    
    protected override State OnUpdate() {
        context.restSpotsScript.campFireStrenght.FireStrenghtReset();
        context.aiStatistics.isLoadingFire = false;
        return State.Success;
    }
}
