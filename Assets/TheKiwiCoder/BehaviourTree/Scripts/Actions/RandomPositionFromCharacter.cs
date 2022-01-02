using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class RandomPositionFromCharacter : ActionNode
{
    public Vector2 min = Vector2.one * -10;
    public Vector2 max = Vector2.one * 10;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        RandomisePostion();
        return State.Success;
    }

    /// <summary>
    /// Generation a random position from the player player character's position
    /// </summary>
    void RandomisePostion() {
        blackboard.moveToPosition.x = Random.Range(context.transform.position.x + min.x, context.transform.position.x + max.x);
        blackboard.moveToPosition.z = Random.Range(context.transform.position.z + min.y, context.transform.position.z + max.y);
        if (NavMesh.SamplePosition(blackboard.moveToPosition, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas)) { // if hte positon is unreachable it generaties another
            return;
        }
        else
        {
            RandomisePostion();
        }
    }
}
