using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFront : MonoBehaviour
{
    [SerializeField] PlayerHSM hsm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("wall"))
        {
            hsm.ChangeState(hsm.hitState);
            SFXManager.Instance.PlayPlayerClip(2);
            SFXManager.Instance.PlayPlayerClip(3);
            ObserverManager.Instance.TriggerAction("GameOver");
        }
    }
}
