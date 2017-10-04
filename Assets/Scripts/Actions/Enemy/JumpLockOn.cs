using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLockOn : MonoBehaviour {

    public PlayerManager player;
    public LayerMask blockLayer;
    
    private enum ATTACK_STATE
    {
        STOP_INITIAL,
        JUMP_MOMENT,
        JUMP_FLOATING,
        STOP_FLOATING,
        STOP_AND_LOCKON,
        STOP_AND_LOCKON_OFF,
        ATTACK_AND_LOCKON_OFF,
        STOP_ON_GROUND,
        WALK_TO_START,

        NONE
    }

    private ATTACK_STATE attackState = ATTACK_STATE.NONE;
    private Rigidbody2D rbody;
    private bool timerStart=false;
    private Timer timer;


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 2;
        timer = GetComponent<Timer>();
 
	}
	
	void FixedUpdate () {

        float distance;
        Vector2 directionVector;
        float speed;
        switch (attackState)
        {
            case ATTACK_STATE.STOP_INITIAL:

                rbody.gravityScale = 2;
                
                if (timer.ElapsedTime > 1f)
                {
                    attackState = ATTACK_STATE.JUMP_MOMENT;
                }
                break;

            case ATTACK_STATE.JUMP_MOMENT:
                rbody.AddForce(new Vector2(0, 400));
                attackState = ATTACK_STATE.JUMP_FLOATING;
                break;
            case ATTACK_STATE.JUMP_FLOATING:
                //時間経過処理
                if (rbody.velocity.y < 0)
                {
                    attackState = ATTACK_STATE.STOP_AND_LOCKON_OFF;
                    timer.Begin();
                }
                break;

            case ATTACK_STATE.STOP_AND_LOCKON_OFF:
                rbody.gravityScale = 0;
                rbody.velocity = new Vector2(0, 0);
                Debug.Log("stop_and_lockon_off");
                Debug.Log(timer.ElapsedTime);
                if (timer.ElapsedTime > 1f)
                {
                    attackState = ATTACK_STATE.STOP_AND_LOCKON;
                    timer.Begin();
                }
                
                break;
            case ATTACK_STATE.STOP_AND_LOCKON:
                Debug.Log("stop_and_lockon");
                if (timer.ElapsedTime > 1f)
                {
                    //距離取得はいらない子
                    distance = Vector2.Distance(player.transform.position, transform.position);
                    directionVector = player.transform.position - transform.position;
                    speed = 10f;
                    rbody.velocity = directionVector.normalized * speed;
                    attackState = ATTACK_STATE.ATTACK_AND_LOCKON_OFF;
                    timer.Begin();
                }
                break;

            case ATTACK_STATE.ATTACK_AND_LOCKON_OFF:
                Debug.Log("attack_and_lockon_off");
                //ラインキャスト処理
                bool isBlock =
                     Physics2D.Linecast(transform.position - (transform.right * 0.3f),
                        transform.position - (transform.up * 0.1f), blockLayer) ||
                     Physics2D.Linecast(transform.position + (transform.right * 0.3f),
                        transform.position - (transform.up * 0.1f), blockLayer);
                if (isBlock||timer.ElapsedTime>3)
                {
                    attackState = ATTACK_STATE.STOP_ON_GROUND;
                    timer.Begin();
                }
                break;

            case ATTACK_STATE.STOP_ON_GROUND:
                Debug.Log("stop_on_ground");
                rbody.gravityScale = 2;
                rbody.velocity = new Vector2(0,0);
                if (timer.ElapsedTime > 3f)
                {
                    attackState = ATTACK_STATE.WALK_TO_START;
                }
                
                break;
            case ATTACK_STATE.WALK_TO_START:
                attackState = ATTACK_STATE.NONE;
                break;

            case ATTACK_STATE.NONE:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    
                    attackState = ATTACK_STATE.STOP_INITIAL;
                    if (player.transform.position.x < transform.position.x)
                    {
                        transform.localScale =
                        new Vector2(transform.localScale.x * -1, transform.localScale.y);
                    }
                    else
                    {
                        transform.localScale =
                            new Vector2(transform.localScale.x, transform.localScale.y);
                    }
                    timer.Begin();
                }
                break;
                

        }
        
	}

}
