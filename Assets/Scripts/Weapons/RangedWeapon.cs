using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : MonoBehaviour {
    public abstract void Init (string tag, Transform attacker);
}
