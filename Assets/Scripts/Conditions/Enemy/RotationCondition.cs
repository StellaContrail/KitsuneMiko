using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCondition : Condition {
    public int num;
    int count = 0;

    public override ConditionState Check (string[] args) {
        ConditionState state = new ConditionState();
        int order = int.Parse(args[0]);
        if (order == count) {
            state.isSatisfied = true;
            count = (count + 1) % num;
        }
        return state;
    }
}
