using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyJump : Action {
    public float vy;
    public Condition onGround;

    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public override bool IsDone() {
        return onGround.Check(new string[0]).isSatisfied;
    }

    public override void Act (Dictionary<string, object> args) {
        if (!IsDone()) {
            return;
        }
        rbody.velocity = new Vector2(rbody.velocity.x, vy);
    }
}
