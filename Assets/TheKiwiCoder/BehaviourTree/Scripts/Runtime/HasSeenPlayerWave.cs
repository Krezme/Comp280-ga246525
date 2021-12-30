using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HasSeenPlayerWave : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.playerCommands.aICommands.isWaving && context.fieldOfView.targetvisible) {  
            context.playerCommands.requredToLookAtPlayer = true; // Requesting to look at the player
            return State.Success;
        }
        return State.Failure;
    }
}
