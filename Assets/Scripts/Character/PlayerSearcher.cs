using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearcher : MonoBehaviour {

    Transform player = null;

    public Transform SearchPlayer () {
        return player;
    }

    void OnTriggerStay2D (Collider2D col) {
        if (col.tag == "Player" && col.GetComponent<Breakable>() != null) {
            player = col.transform;
        }
    }

    void OnTriggerExist2D (Collider2D col) {
        player = null;
    }
}
