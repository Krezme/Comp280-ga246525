using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToPosition : ActionNode
{
    public float speed = 5; //speed for the AI
    public float stoppingDistance = 0.1f; //how far from the destination does the AI have to be to stop 
    public bool updateRotation = true; //if in agend build in rotation update of the AI needed to be used
    public float acceleration = 40.0f; //The agent acceleration
    public float tolerance = 1.0f; //The distance when the node is considered to be a Success

    protected override void OnStart() {
        //setting all of these variables to the AI's agend
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.moveToPosition;
        context.agent.updateRotation = updateRotation;
        context.agent.acceleration = acceleration;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance) {
            return State.Success;
        }
        else
        {
            context.agent.destination = blackboard.moveToPosition;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Running;
    }
}
