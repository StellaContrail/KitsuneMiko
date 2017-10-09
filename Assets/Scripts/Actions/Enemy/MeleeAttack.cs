using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeAttack : Action {
    public string rangeName;
    public string animationTrigger;

    GameObject weapon;
    Animator animator;

    void Start () {
        weapon = transform.Find(rangeName).gameObject;
        animator = GetComponent<Animator>();
    }

    bool _isDone = true;
    public override bool IsDone () {
        return _isDone;
    }

    public void MeleeAttackEnd () {
        weapon.SetActive(false);
        _isDone = true;
    }

    public override void Act (Dictionary<string, object> args) {
        if (!_isDone) {
            return;
        }
        _isDone = false;
        animator.SetTrigger(animationTrigger);
        weapon.SetActive(true);
    }
}
