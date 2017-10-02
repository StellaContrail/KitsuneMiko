using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAcorn : Action {

    bool _isDone = true;
    public override bool IsDone () {
        return _isDone;
    }

    public void OnAnimationEnd () {
        _isDone = true;
    }

    public override void Act (Dictionary<string, object> args) {
        if (!_isDone) {
            return;
        }
        _isDone = false;
        GameObject acornObj = Resources.Load("Prefab/Acorn") as GameObject;
        Acorn acorn = acornObj.GetComponent<Acorn>();
        acorn.Init(tag, transform.position, transform.localScale.x);
    }
}
