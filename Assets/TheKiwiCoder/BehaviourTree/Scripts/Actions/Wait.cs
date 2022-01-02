using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    public class Wait : ActionNode {
        public float duration = 1;
        float startTime;

        protected override void OnStart() {
            startTime = Time.time;
        }

        protected override void OnStop() {
        }

        //Waiting the duration specified in the editor (by default is 1 second)
        protected override State OnUpdate() {
            if (Time.time - startTime > duration) {
                return State.Success;
            }
            return State.Running;
        }
    }
}
