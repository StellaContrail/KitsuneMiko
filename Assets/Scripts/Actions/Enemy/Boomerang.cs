using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    public float speed=3;
    public float offset_y;

    private const int OVER_RUN = 10;
    private Rigidbody2D rbody;
    private bool returnToThrower=false;
    private bool returnAtThrower = false;
    private Vector2 targetPosition;
    private enum DIRECTION
    {
        RIGHT=1,
        LEFT=-1,
        
        NONE      
    }

    private DIRECTION direction = DIRECTION.NONE;
    private Vector2 directionVector;
    private Vector2 ReturnAtVector;
    public void Ini(Transform transform,Vector2 targetPosiiton)
    {
        this.transform.position = transform.position;
        this.targetPosition= targetPosiiton;
        if (transform.localScale.x<0)
        {
            direction = DIRECTION.LEFT;
            ReturnAtVector = new Vector2(targetPosiiton.x - OVER_RUN, targetPosiiton.y);
        }
        else
        {
            direction = DIRECTION.RIGHT;
            ReturnAtVector = new Vector2(targetPosiiton.x + OVER_RUN,targetPosiiton.y);
        }
    }

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        directionVector = ReturnAtVector - (Vector2)transform.position;
        speed = 10f;

        
        switch (direction)
        {
            case DIRECTION.RIGHT:
                if (0<=directionVector.x)
                {

                    if (returnToThrower == false)
                    {
                        if (targetPosition.x-transform.position.x < 0)
                        {
                            returnToThrower = true;
                            direction = DIRECTION.LEFT;
                        }
                    }
                    else
                    {
                        if (returnAtThrower == false)
                        {
                            returnAtThrower = true;
                        }
                    }
                }

                break;
            case DIRECTION.LEFT:
                if (directionVector.x<=0)
                {
                    
                    if (returnToThrower == false)
                    {
                        if (transform.position.x - targetPosition.x < 0)
                        {
                            returnToThrower = true;
                            direction = DIRECTION.RIGHT;
                        }
                        
                    }else
                    {
                        if (returnAtThrower == false)
                        {
                            returnAtThrower = true;
                        }
                    }
                    
                }
                break;
        }

        if (returnAtThrower)
        {
            Destroy(this.gameObject);
        }
        
        
        rbody.velocity = new Vector2((float)direction * speed, 0);


	}

   
}
