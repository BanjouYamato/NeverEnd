using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurn : TurnTrigger
{
    protected override void TriggerTurn()
    {
        if (Input.GetKeyDown(KeyCode.X) || PlayerSkill.Instance.speedUp)
        {
            ObserverManager.Instance.TriggerAction("TurnLeft");
            Collider col = GetComponent<Collider>();
            col.enabled = false;
            Debug.Log("left");
        }
    }
}
