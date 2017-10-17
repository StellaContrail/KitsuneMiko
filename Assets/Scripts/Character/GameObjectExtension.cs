using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension {

    class MotionState {
        Rigidbody2D rbody;
        Animator animator;
        ActionManager actionManager;
        bool isKinematic;
        Vector2 velocity;
        float anglerVelocity;

        public int pauseCallCount = 0;

        public MotionState (GameObject obj) {
            rbody = obj.GetComponent<Rigidbody2D>();
            animator = obj.GetComponent<Animator>();
            actionManager = obj.GetComponent<ActionManager>();
        }

        public void Pause () {
            if (pauseCallCount == 0) {
                if (animator != null) {
                    animator.speed = 0.0f;
                }
                if (actionManager != null) {
                    actionManager.enabled = false;
                }
                if (rbody != null) {
                    velocity = rbody.velocity;
                    rbody.velocity = Vector2.zero;
                    anglerVelocity = rbody.angularVelocity;
                    rbody.angularVelocity = 0.0f;
                    isKinematic = rbody.isKinematic;
                    rbody.isKinematic = true;
                }
            }
            pauseCallCount++;
        }

        public void Resume () {
            pauseCallCount--;
            if (pauseCallCount == 0) {
                if (rbody != null) {
                    rbody.isKinematic = isKinematic;
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
    }

    static Dictionary<GameObject, MotionState> motionStates
        = new Dictionary<GameObject, MotionState>();

    public static void Pause (this GameObject obj) {
        MotionState state;
        if (motionStates.ContainsKey(obj)) {
            state = motionStates[obj];
        } else {
            state = new MotionState(obj);
            motionStates.Add(obj, state);
        }
        state.Pause();
    }

    public static void Resume (this GameObject obj) {
        MotionState state = motionStates[obj];
        state.Resume();
        if (state.pauseCallCount == 0) {
            motionStates.Remove(obj);
        }
    }
}
