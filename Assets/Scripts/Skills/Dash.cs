using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill {

    public float dashSpeed = 15f;
    public float dashUprisingSpeed = 8f;
    public int keyReceivingFrames = 35;
    public int dashingFrames = 10;

    int intervalTime = 0;
    bool isDashReserved = false;
    KeyCode pressedKeyCode = KeyCode.None;

    public override float cost
    {
        get
        {
            return 0.8f;
        }
    }

	protected override void Awake()
    {
        base.Awake();
    }

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		// 一度キーが押されてから一定時間内にもう一度押されれば実行
		// 複数矢印キーをDetectしているため、押される順番がネック。
		// もし同時押しが発生した場合はキャンセルする
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (isDashReserved)
			{
				if (keyReceivingFrames >= intervalTime && pressedKeyCode == KeyCode.RightArrow)
				{
                    intervalTime = 0;
                    pressedKeyCode = KeyCode.None;
                    gameObject.GetComponent<PlayerWalk>().disable();
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * dashSpeed + Vector2.up * dashUprisingSpeed;
                }
			}
			else
			{
				pressedKeyCode = KeyCode.RightArrow;
				isDashReserved = true;
			}
            
        }
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (isDashReserved)
			{
				if (keyReceivingFrames >= intervalTime && pressedKeyCode == KeyCode.LeftArrow)
				{
                    intervalTime = 0;
                    pressedKeyCode = KeyCode.None;
                    gameObject.GetComponent<PlayerWalk>().disable();
                    gameObject.GetComponent<Rigidbody2D>().velocity = -1f * Vector2.right * dashSpeed + Vector2.up * dashUprisingSpeed;
				}
			}
			else
			{
				pressedKeyCode = KeyCode.LeftArrow;
				isDashReserved = true;
			}
        }
		
		if (isDashReserved && pressedKeyCode != KeyCode.None)
		{
            intervalTime++;
			if (intervalTime > keyReceivingFrames)
			{
                intervalTime = 0;
                isDashReserved = false;
                pressedKeyCode = KeyCode.None;
            }
        }

		if (isDashReserved && pressedKeyCode == KeyCode.None)
		{
            intervalTime++;
            if (intervalTime > dashingFrames)
			{
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<PlayerWalk>().enable();
                isDashReserved = false;
                intervalTime = 0;
            }
        }

	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		
	}

}
