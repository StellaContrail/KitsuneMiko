using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {
    static readonly Dictionary<string, HashSet<string>> DAMAGE_TAGS
        = new Dictionary<string, HashSet<string>> {
            {"Player", new HashSet<string> {"Enemy", "Neutral"}},
            {"Enemy", new HashSet<string> {"Player", "Neutral"}},
            {"Neutral", new HashSet<string> {"Player", "Enemy", "Neutral"}}
        };

    public float maxHitPoint;
    public float defencePoint = 1.0f;

    [System.NonSerialized]
    public float hitPoint;

    Capturable capturable;

    public int invFrameNum = 0;
    int invFrameCount = 0;
    bool isInvByDamage = false;

    [System.NonSerialized]
    public bool isInvincible = false;

    public int hitStopFrameNum = 20;
    int hitStopFrameCnt = 0;
    bool isHitStopping = false;

    void Awake () {
        hitPoint = maxHitPoint;
    }

    void Start () {
        capturable = GetComponent<Capturable>();
    }

    void FixedUpdate () {
        if (hitPoint <= 0.0f) {
            GetComponent<Death>().enabled = true;
        } else if (capturable != null) {
            float boundary = capturable.hitPointBoundary;
            if (!capturable.enabled && hitPoint <= boundary) {
                capturable.enabled = true;
            } else if (capturable.enabled && hitPoint > boundary) {
                capturable.enabled = false;
            }
        }
        if (isInvByDamage) {
            invFrameCount++;
            if (invFrameCount > invFrameNum) {
                invFrameCount = 0;
                isInvincible = false;
                isInvByDamage = false;
            }
        }
        if (isHitStopping) {
            hitStopFrameCnt++;
            if (hitStopFrameCnt > hitStopFrameNum) {
                hitStopFrameCnt = 0;
                gameObject.Resume();
                isHitStopping = false;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (isInvincible) {
            return;
        }
        if (DAMAGE_TAGS[tag].Contains(col.tag)) {
            Damage damage = col.GetComponent<Damage>();
            if (damage != null) {
                damage.Apply(this);
                if (invFrameNum != 0) {
                    isInvByDamage = true;
                    isInvincible = true;
                }
                if (hitStopFrameNum != 0) {
                    isHitStopping = true;
                    gameObject.Pause();
                }
            }
        }
    }
}
