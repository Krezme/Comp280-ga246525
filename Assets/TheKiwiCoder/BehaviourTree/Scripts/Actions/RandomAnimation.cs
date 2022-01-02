using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomAnimation : ActionNode
{
    public int randomMin;
    public int randomMax;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    /// <summary>
    /// Choosing a random animation that can be played in some cases
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate() {
        blackboard.randomAnimInt = Random.Range(randomMin, randomMax +1);
        return State.Success;
    }
}
