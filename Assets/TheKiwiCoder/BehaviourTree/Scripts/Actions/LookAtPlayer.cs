using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class LookAtPlayer : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.playerCommands.requredToLookAtPlayer) { // Waiting for a request to look at the player from the previous node
            context.agent.updateRotation = false; 
            Vector3 lookPos = context.playerCommands.player.transform.position - context.transform.position;
            lookPos.y = 0;
            context.transform.rotation  = Quaternion.LookRotation(lookPos);
            return State.Running;
        }
        context.agent.updateRotation = true;
        return State.Success;
    }
}
