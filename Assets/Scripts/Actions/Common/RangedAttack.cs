using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Actions/Common/Ranged Attack")]
[RequireComponent(typeof(Animator))]
public class RangedAttack : Action {

    public GameObject weaponPrefab;
    public string animationTrigger;

    Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
    }

    bool _isDone = true;
    public override bool IsDone () {
        return _isDone;
    }

    public void RangedAttackEnd () {
        _isDone = true;
    }

    public override void Act (Dictionary<string, object> args) {
        if (!_isDone) {
            return;
        }
        _isDone = false;
        animator.SetTrigger(animationTrigger);
    }

    public void GenerateWeapon () {
        Instantiate(weaponPrefab)
            .GetComponent<RangedWeapon>().Init(tag, transform);
    }
}
