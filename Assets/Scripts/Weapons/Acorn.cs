using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour {
    static readonly float V_IX = 0.5f;
    static readonly float V_IY = 0.5f;
    static readonly float OMEGA = 1.0f;

    Rigidbody2D rbody;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Init (string tag, Vector2 pos, float signX) {
        this.tag = tag;
        transform.position = pos;
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
