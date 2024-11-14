using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trap") ||
            other.CompareTag("coinLine")
            || other.CompareTag("enemy")) other.gameObject.SetActive(false);
    }

}
