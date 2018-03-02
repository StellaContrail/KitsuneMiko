using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill {

    int intervalTime;
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
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            pressedKeyCode = KeyCode.RightArrow;
        }
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		
	}

}
