using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JumpRectangle : Action
{
    private const int ENEMY_POINT = 50;//敵の得点
    private GameObject gameManager;//ゲームマネージャー

    public LayerMask blockLayer;

    private Rigidbody2D rbody;

    private float moveSpeed = 2;

    public enum MOVE_DIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    }

    private MOVE_DIR moveDirection = MOVE_DIR.UP;//移動方法

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        bool isBlock = false;

        Vector3 bossPosition;

        if (moveDirection == MOVE_DIR.UP)
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y + 0.5f);
            //transform.localScale = new Vector2(1, 1);

            bossPosition = transform.position;

            if (bossPosition.y > 3.3f)
            {
                if (bossPosition.x < 0)
                {
                    moveDirection = MOVE_DIR.RIGHT;
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    moveDirection = MOVE_DIR.LEFT;
                    transform.localScale = new Vector2(1, 1);

                }
            }
        }

        if (moveDirection == MOVE_DIR.RIGHT)
        {
            rbody.velocity = new Vector2(moveSpeed, 0);
            //transform.localScale = new Vector2(1, 1);

            bossPosition = transform.position;

            if (bossPosition.x > 6.0f)
            {
                moveDirection = MOVE_DIR.DOWN;
                transform.localScale = new Vector2(-1, 1);

            }

        }

        if (moveDirection == MOVE_DIR.LEFT)
        {
            rbody.velocity = new Vector2(-moveSpeed, 0);
            //transform.localScale = new Vector2(1, 1);

            bossPosition = transform.position;

            if (bossPosition.x < -6.0f)
            {
                moveDirection = MOVE_DIR.DOWN;
                transform.localScale = new Vector2(1, 1);

            }

        }

        if (moveDirection == MOVE_DIR.DOWN)
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y - 0.5f);
            transform.localScale = new Vector2(1, 1);

            bossPosition = transform.position;

        }



    }

    public override bool IsDone()
    {
        return true;
    }

    public override void Act(Dictionary<string, object> args)
    {

    }

    public void DestroyEnemy()
    {
        gameManager.GetComponent<GameManager>().AddScore(ENEMY_POINT);

        rbody.velocity = new Vector2(0, 0);
        //コライダー削除
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Destroy(circleCollider);
        Destroy(boxCollider);
        //死亡モーション
        Sequence animSet = DOTween.Sequence();
        animSet.Append(transform.DOLocalMoveY(0.5f, 0.2f).SetRelative());
        animSet.Append(transform.DOLocalMoveY(-10.0f, 1.0f).SetRelative());

        Destroy(this.gameObject, 1.2f);
    }

}
