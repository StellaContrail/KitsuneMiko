using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamaitachi : Skill
{
    public float X_DIFF = -0.5f;
    public float Y_DIFF = 0.8f;
    public float DEPTH = -1f;
    public GameObject moonBullet;

    public override float cost
    {
        get
        {
            return 1.5f;
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        // if this skill is enabled, attack key is rebounden as this skill
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 pos = new Vector3(
                transform.position.x + (float)transform.GetFaceDir().Reverse() - X_DIFF,
                transform.position.y + Y_DIFF,
                DEPTH
            );
            Instantiate(moonBullet, pos, Quaternion.identity).GetComponent<MoonBullet>().Init(gameObject);
        }
    }
}
