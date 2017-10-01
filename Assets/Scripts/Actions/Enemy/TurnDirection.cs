using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDirection : Action {
    public override bool IsDone () {
        return true;
    }

    public override void Act (Dictionary<string, object> args) {
        transform.localScale
            = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
    }
}
