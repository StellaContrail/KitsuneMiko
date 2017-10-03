using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Action {

    GameObject weapon;

    void Start () {
        weapon = GetComponentInChildren<Damage>().gameObject;
    }

    bool _isDone = true;
    public override bool IsDone () {
        return _isDone;
    }

    public void OnAnimationEnd () {
        weapon.SetActive(false);
        _isDone = true;
    }

    public override void Act (Dictionary<string, object> args) {
        if (!_isDone) {
            return;
        }
        _isDone = false;
        weapon.SetActive(true);
    }
}
