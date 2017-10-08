using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour {

    public virtual void Init (string tag, Transform attacker) {
        this.tag = tag;
        transform.position = attacker.position;
        transform.localScale = new Vector2(attacker.localScale.x, 1);
    }
}
