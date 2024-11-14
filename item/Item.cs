using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract void Effect();

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Effect();
            gameObject.SetActive(false);
            SFXManager.Instance.PlayGainItemClip(0);
        }
    }
}
