using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Stop : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    //Stopping the AI from moving
    protected override State OnUpdate() {
        context.agent.destination = context.transform.position;
        return State.Success;
    }
}
