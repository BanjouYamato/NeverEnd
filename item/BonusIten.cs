using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusIten : Item
{
    protected override void Effect()
    {
        ObserverManager.Instance.TriggerAction("x2Score");
    }
}
