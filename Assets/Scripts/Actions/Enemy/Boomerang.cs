using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    
    private const int OVER_RUN = 3;
    private Rigidbody2D rbody;
    private bool returnToThrower=false;
    private bool returnAtThrower = false;
    private Vector2 targetPosition;
    private enum THROW_DIRECTION
    {
        RIGHT,
        LEFT,
        
        NONE      
    }

    private THROW_DIRECTION throwDirection = THROW_DIRECTION.NONE; 
    private Vector2 directionVector;
    private Vector2 returnAtVector;
    private Vector2 iniVector;
    private int direction;
    public float boomerangSpeed;
    public float offset_y;

    public void Ini(Transform transform,Vector2 targetPosiiton)
    {
        iniVector = transform.position;
        this.transform.position = transform.position;
        

        this.targetPosition= targetPosiiton;
        if (transform.localScale.x<0)
        {
            throwDirection = THROW_DIRECTION.LEFT;
            returnAtVector = new Vector2(targetPosiiton.x - OVER_RUN, targetPosiiton.y);
        }
        else
        {
            throwDirection = THROW_DIRECTION.RIGHT;
            returnAtVector = new Vector2(targetPosiiton.x + OVER_RUN,targetPosiiton.y);
        }
    }

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        directionVector = returnAtVector - (Vector2)transform.position;

        
        switch (throwDirection)
        {
            case THROW_DIRECTION.RIGHT:
                if (directionVector.x>0)
                {
                    direction = 1;
                }
                else
                {
                    returnToThrower = true;
                }

                if (returnToThrower)
                {
                    
                    direction = -1;
                    if (iniVector.x > transform.position.x)
                    {
                        returnAtThrower = true;
                    }
                }
               
                break;
            case THROW_DIRECTION.LEFT:
                if (directionVector.x < 0)
                {
                    direction = -1;

                }else
                {
                    returnToThrower = true;
                }

                if(returnToThrower)
                {
                    direction = 1;
                    if (iniVector.x < transform.position.x)
                    {
                        returnAtThrower = true;
                    }
                }
                break;
        }

        if (returnAtThrower)
        {
            Destroy(this.gameObject);
        }
        
        
        rbody.velocity =new Vector2(direction * boomerangSpeed,0);
        Debug.Log(rbody.velocity);

	}

   
}
