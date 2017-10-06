using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearcher : MonoBehaviour {

    Transform player = null;

    public Transform SearchPlayer () {
        return player;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (player != null) {
            return;
        }
        if (col.tag == "Player" && col.GetComponentInParent<Breakable>() != null) {
            player = col.transform;
        }
    }

    void OnTriggerExist2D (Collider2D col) {
        player = null;
    }
}
