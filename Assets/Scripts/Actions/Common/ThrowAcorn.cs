using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAcorn : Action {

    public GameObject acornPrefab;

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
        Instantiate(acornPrefab, transform.position, Quaternion.identity)
            .GetComponent<Acorn>().Init(tag, transform.localScale.x);
    }
}
