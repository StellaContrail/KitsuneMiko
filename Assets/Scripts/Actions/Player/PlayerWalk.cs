using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : Action {

    public AnimatorOverrideController runChargeAnim;
    public AnimatorOverrideController idleChargeAnim;

    bool _isDone = true;

    public override bool IsDone()
    {
        return _isDone;
    }

    bool walkable = true;
    public void enable()
    {
        walkable = true;
    }

    public void disable()
    {
        walkable = false;
    }

    int i = 0;
    public float walkSpeed = 3f;
    [System.NonSerialized]
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
            gameObject.GetComponent<Animator>().SetBool("walk", false);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("walk", Mathf.Abs(moveSpeed) > 0);
            if (Mathf.Abs(moveSpeed) > 0 && gameObject.GetComponent<PlayerOnGroundCondition>().IsPlayerOnGround)
            {
                gameObject.GetComponent<PlayerEffectManager>().ShowPlayerEffect("Walking");
            }
        }

        if (walkable)
        {
            rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
        }

        // 歩いている時はAnimatorをOverrideしてCharge時アニメーションを変えるようにしている
        if (Mathf.Abs(moveSpeed) > 0)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = runChargeAnim;
        }
        else
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = idleChargeAnim;
        }

    }
}
