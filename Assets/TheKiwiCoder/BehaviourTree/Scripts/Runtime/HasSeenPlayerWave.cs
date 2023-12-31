using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HasSeenPlayerWave : ActionNode
{
    public bool checkForWave;
    public bool checkForFollowWave;
    public bool checkForStopFollowWave;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }
    /// <summary>
    /// Checking for whichever wave is specified in the editor (using the 3 bools above)
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate() {
        if (context.playerCommands.aICommands.isWaving && context.fieldOfView.targetvisible && checkForWave) {  
            context.playerCommands.requredToLookAtPlayer = true; // Requesting to look at the player
            return State.Success;
        }
        if (context.playerCommands.aICommands.isFollowWaving && context.fieldOfView.targetvisible && checkForFollowWave) {
            context.playerCommands.requredToLookAtPlayer = true;
            context.playerCommands.isFollowing = true; // Request to follow player;
            return State.Success;
        }else if (context.playerCommands.isFollowing && checkForFollowWave) {
            context.playerCommands.requredToLookAtPlayer = true;
            return State.Success;
        }
        if (context.playerCommands.aICommands.isStopFollowWaving && context.fieldOfView.targetvisible && checkForStopFollowWave) {
            context.playerCommands.requredToLookAtPlayer = false;
            context.playerCommands.isFollowing = false;// Request to stop follow player;
            return State.Success;
        }
        return State.Failure;
    }
}
