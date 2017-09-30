using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : Damage {
    static SortedDictionary<int, DamageAttribute> commonAttributes
        = new SortedDictionary<int, DamageAttribute>();

    public new static void AddAttributes (DamageAttribute[] attrs) {
        foreach (DamageAttribute attr in attrs) {
            commonAttributes.Add(attr.order, attr);
        }
    }

    public new static void RemoveAttributes (DamageAttribute[] attrs) {
        foreach (DamageAttribute attr in attrs) {
            commonAttributes.Remove(attr.order);
        }
    }

    public override void ApplyDamage (Breakable breakable) {
        float initHP = breakable.hitPoint;
        base.ApplyDamage(breakable);
        foreach (DamageAttribute attr in commonAttributes.Values) {
            attr.Apply(this, breakable, initHP);
        }
    }
}
