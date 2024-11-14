using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTurn : TurnTrigger
{
    protected override void TriggerTurn()
    {
        if(Input.GetKeyDown(KeyCode.C) || PlayerSkill.Instance.speedUp)
        {
            ObserverManager.Instance.TriggerAction("TurnRight");
            Collider col = GetComponent<Collider>();
            col.enabled = false;
            Debug.Log("right");
        }
    }
}
