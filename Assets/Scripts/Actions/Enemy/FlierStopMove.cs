using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlierStopMove : Action {
    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public override bool IsDone () {
        return true;
    }

    public override void Act (Dictionary<string, object> args) {
        rbody.velocity = new Vector2(0.0f, 0.0f);
    }
}
