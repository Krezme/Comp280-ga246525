using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RequredToLookAtPlayer : ActionNode
{
    public bool lookAtPlayerState;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    /// <summary>
    /// Setting the AI to look at the player
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate() {
        context.playerCommands.requredToLookAtPlayer = lookAtPlayerState;
        return State.Success;
    }
}
