using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsible : Skill {

	public override float cost {
        get {
            return 0.5f;
        }
    }

    protected override void Awake () {
        breakable = GetComponent<Breakable>();
        base.Awake();
    }

}
