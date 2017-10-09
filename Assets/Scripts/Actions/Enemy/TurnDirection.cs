using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDirection : Action {

    public override bool IsDone () {
        return true;
    }

    public override void Act (Dictionary<string, object> args) {
        transform.FaceDir(transform.FaceDir().Reverse());
    }
}
