using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Action {
    public float speed;

    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public override bool IsDone () {
        return true;
    }

    public override void Act (Dictionary<string, object> args) {
        rbody.velocity = new Vector2(transform.localScale.x * speed, rbody.velocity.y);
    }
}
