using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRush : Action {

    private Rigidbody2D rbody;

    private float moveSpeed = 4;

    Vector3 bossPosition;

    int count = 0;

    public enum MOVE_DIR
    {
        LEFT,
        RIGHT,
    }

    public enum MOVE_STATUS
    {
        MOVING,
        WAITING,
    }

    private MOVE_DIR moveDirection = MOVE_DIR.LEFT;//移動方法
    private MOVE_STATUS moveStatus = MOVE_STATUS.WAITING;//移動方法

    public override bool IsDone()
    {
        return true;
    }

    public override void Act(Dictionary<string, object> args)
    {

    }

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        bossPosition = transform.position;
        count = 0;

        if (bossPosition.x > 0)
        {
            moveDirection = MOVE_DIR.LEFT;
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            moveDirection = MOVE_DIR.RIGHT;
            transform.localScale = new Vector2(-1, 1);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if(moveStatus == MOVE_STATUS.WAITING)
        {

            if (count < 120)
            {
                count++;
            }

            if (count == 120)
            {
                moveStatus = MOVE_STATUS.MOVING;
            }

          
        }

        if(moveStatus == MOVE_STATUS.MOVING)
        {
            if (moveDirection == MOVE_DIR.RIGHT)
            {
                rbody.velocity = new Vector2(moveSpeed, 0);
                bossPosition = transform.position;

                if (bossPosition.x > 6.0f)
                {
                    moveStatus = MOVE_STATUS.WAITING;
                    rbody.velocity = new Vector2(0, 0);


                }

            }

            if (moveDirection == MOVE_DIR.LEFT)
            {
                rbody.velocity = new Vector2(-moveSpeed, 0);
                bossPosition = transform.position;

                if (bossPosition.x < -6.0f)
                {
                    moveStatus = MOVE_STATUS.WAITING;
                    rbody.velocity = new Vector2(0, 0);

                }

            }


        }

        

    }
}
