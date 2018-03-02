using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsible : Skill {

    Breakable breakable;

    public int DURATION = 50;
    int _invFrameNum;


    public override float cost {
        get {
            return 0.5f;
        }
    }

    protected override void Awake () {
        breakable = GetComponent<Breakable>();
        base.Awake();
        _invFrameNum = breakable.invFrameNum;
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        breakable.invFrameNum = DURATION;
        breakable.BeginInvincible();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        breakable.invFrameNum = _invFrameNum;
    }

}
