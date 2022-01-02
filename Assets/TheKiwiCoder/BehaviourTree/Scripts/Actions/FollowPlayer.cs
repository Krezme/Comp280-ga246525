using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FollowPlayer : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Constantly updates the position that the AI needs to move to when it has been required to follow the player
        if (context.playerCommands.isFollowing) {
            blackboard.moveToPosition = context.playerCommands.player.transform.position;
            return State.Success;
        }
        return State.Failure;
    }
}
