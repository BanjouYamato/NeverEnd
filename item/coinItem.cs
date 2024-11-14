using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinItem : Item
{
    protected override void Effect()
    {
        ObserverManager.Instance.TriggerAction("coin");
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Effect();
            gameObject.SetActive(false);
            SFXManager.Instance.PlayGainItemClip(1);
        }
    }
}
