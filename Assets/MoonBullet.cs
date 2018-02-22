using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBullet : MonoBehaviour {

    Rigidbody2D rbody;
    GameObject player;
    bool isToInitialize = false;
    float initialXPos;

    public float RANGE = 50f;
    public float VELOCITY_ENCHANCEMENT = 10f;
    public void Init(GameObject _player)
    {
        rbody = GetComponent<Rigidbody2D>();
        isToInitialize = true;
        player = _player;
        initialXPos = Mathf.Abs(transform.position.x);
    }

    void FixedUpdate()
    {
        if (isToInitialize)
        {
            isToInitialize = false;
            rbody.velocity = new Vector2((float)player.transform.GetFaceDir().Reverse() * VELOCITY_ENCHANCEMENT, 0f);
        }
        if (Mathf.Abs(transform.position.x) > initialXPos + RANGE)
        {
            Destroy(gameObject);
            Debug.Log("destroyed by out of range");
        }
    }

    // TODO: Need a tag that only detects Hitrange bc detector detects SearchRange as well
    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag != tag) {
            Destroy(gameObject);
            Debug.Log("destroyed by " + col.name);
        }
    }
}
