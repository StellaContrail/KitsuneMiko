using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : Action {

    bool _isDone = true;

    public override bool IsDone()
    {
        return _isDone;
    }

    int i = 0;
    public float walkSpeed = 3f;
    public float moveSpeed = 0f;
    public override void Act(Dictionary<string, object> args)
    {
        Rigidbody2D rbody = gameObject.GetComponent<Rigidbody2D>();
        switch ((PlayerWalkCondition.WALK_DIR)System.Enum.Parse(typeof(PlayerWalkCondition.WALK_DIR), (string)args["movingDirection"]))
        {
            case PlayerWalkCondition.WALK_DIR.IDLE:
                _isDone = true;
                moveSpeed = 0;
                break;
            case PlayerWalkCondition.WALK_DIR.LEFT:
                _isDone = false;
                moveSpeed = walkSpeed * -1;
                transform.localScale = new Vector2(1, 1);
                break;
            case PlayerWalkCondition.WALK_DIR.RIGHT:
                _isDone = false;
                moveSpeed = walkSpeed;
                transform.localScale = new Vector2(-1, 1);
                break;
        }

        bool isCharging = gameObject.GetComponent<PlayerChargeStart>().IsCharging;
        bool isReleasing = gameObject.GetComponent<PlayerChargeEndCondition>().isReleasing;
        if (isCharging || isReleasing) 
        {
            gameObject.GetComponent<Animator>().SetBool("stop", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("stop", moveSpeed == 0);
        }

        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
    }
}
