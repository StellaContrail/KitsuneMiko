using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeEndCondition : Condition
{
    PlayerChargeStart playerChargeStart;
    ConditionState Status;
    public override ConditionState Check(string[] args)
    {
        return Status;
    }

    // Use this for initialization
    void Start()
    {
        Status = new ConditionState();
        Status.isSatisfied = false;
        playerChargeStart = gameObject.GetComponent<PlayerChargeStart>();
    }

    public void Deactivate()
    {
        Status.isSatisfied = false;
        isReleasing = false;
    }

    public float chargingTime = 1f;
    [System.NonSerialized]
    public bool isReleasing = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && playerChargeStart.IsCharging)
        {
            // Chargingをしていて、経過時間がchargeTimeを超えていてチャージボタンを離すときにとActを呼び出す
            if (playerChargeStart.ElapsedTime > chargingTime)
            {
                //if player is walking, charge will be cancelled
                if (gameObject.GetComponent<PlayerWalk>().moveSpeed == 0)
                {
                    Status.args["isFullyCharged"] = true;
                    isReleasing = true;
                }
                else
                {
                    Debug.Log("Initialized");
                    playerChargeStart.resetChargeTime();
                    Status.args["isFullyCharged"] = false;
                    isReleasing = false;
                }
                
            }
            // Charge中にー時ボタンを離されたとき初期化する
            else
            {
                Debug.Log("Initialized");
                playerChargeStart.resetChargeTime();
                Status.args["isFullyCharged"] = false;
            }
            playerChargeStart.IsCharging = false;
            Status.isSatisfied = true;
            gameObject.GetComponent<PlayerChargeStart>()._IsDone = true;
        }
    }
}
