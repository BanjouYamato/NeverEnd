using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : Item
{
    protected override void Effect()
    {
        ObserverManager.Instance.TriggerAction("jumpSkill");
        
    }
}
