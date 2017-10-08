using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension {

    class MotionState {
        Rigidbody2D rbody;
        Animator animator;
        ActionManager actionManager;
        Vector2 velocity;
        float anglerVelocity;

        public MotionState (GameObject obj) {
            rbody = obj.GetComponent<Rigidbody2D>();
            animator = obj.GetComponent<Animator>();
            actionManager = obj.GetComponent<ActionManager>();
        }

        public void Pause () {
            if (animator != null) {
                animator.speed = 0.0f;
                velocity = rbody.velocity;
                anglerVelocity = rbody.angularVelocity;
            }
            if (actionManager != null) {
                actionManager.enabled = false;
            }
            if (rbody != null) {
                rbody.isKinematic = false;
            }
        }

        public void Resume () {
            if (rbody != null) {
                rbody.isKinematic = true;
                rbody.velocity = velocity;
                rbody.angularVelocity = anglerVelocity;
            }
            if (actionManager != null) {
                actionManager.enabled = true;
            }
            if (animator != null) {
                animator.speed = 1.0f;
            }
        }
    }

    static Dictionary<GameObject, MotionState> motionStates
        = new Dictionary<GameObject, MotionState>();

    public static void Pause (this GameObject obj) {
        MotionState state = new MotionState(obj);
        state.Pause();
        motionStates.Add(obj, state);
    }

    public static void Resume (this GameObject obj) {
        motionStates[obj].Resume();
        motionStates.Remove(obj);
    }
}
