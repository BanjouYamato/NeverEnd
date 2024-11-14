using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
{
    protected override void Effect()
    {
        ObserverManager.Instance.TriggerAction("speedSkill");
        Debug.Log("ok");
    }
}
