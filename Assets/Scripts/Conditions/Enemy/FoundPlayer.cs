using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPlayer : Condition {

    PlayerSearcher searcher;

    void Start () {
        searcher = GetComponentInChildren<PlayerSearcher>();
    }

    public override ConditionState Check (string[] args) {
        Transform player = searcher.SearchPlayer();
        if (player == null) {
            return new ConditionState();
        } else {
            return new ConditionState(
                true,
                new Dictionary<string, object> {{"playerTransform", player}}
            );
        }
    }
}
