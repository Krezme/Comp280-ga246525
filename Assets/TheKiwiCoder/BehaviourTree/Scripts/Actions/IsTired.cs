using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//This action node is used to inisiate the tired behaviour branches
public class IsTired : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //switching to tired behaviour 
        if (context.aiStatistics.currentStatistics.energy <= context.aiStatistics.aiTresholds.tiredness) {
            context.animator.SetBool("Tired", true);
            context.animator.SetBool("Happy", false);
            return State.Success;
        }
        context.animator.SetBool("Tired", false);
        return State.Failure;
    }
}
