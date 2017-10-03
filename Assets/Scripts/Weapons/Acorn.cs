using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : RangedWeapon {
    static readonly float V_IX = 0.5f;
    static readonly float V_IY = 0.5f;
    static readonly float OMEGA = 1.0f;

    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public override void Init (string tag, Transform attacker) {
        this.tag = tag;
        transform.position = attacker.position;
        float signX = attacker.localScale.x;
        transform.localScale = new Vector2(signX, 1);
        rbody.velocity = new Vector2(signX * V_IX, V_IY);
        rbody.angularVelocity = signX * OMEGA;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag != tag) {
            Destroy(gameObject);
        }
    }
}
