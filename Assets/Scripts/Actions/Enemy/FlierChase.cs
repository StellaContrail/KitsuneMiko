using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlierChase : Action {
    public float speed;

    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public override bool IsDone () {
        return true;
    }

    public override void Act (Dictionary<string, object> args) {
        Transform target = (Transform)args["target"];
        Vector2 dir = ((Vector2)(target.position - transform.position)).normalized;
        rbody.velocity = speed * dir;
    }
}
