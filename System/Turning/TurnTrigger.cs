using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnTrigger : MonoBehaviour
{
    [SerializeField] protected PlayerSkill skill;
    protected GameObject Player;


    protected abstract void TriggerTurn();

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTurn();
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTurn();
        }
    }
    protected void OnDisable()
    {
        Collider col = GetComponent<Collider>();
        col.enabled = true;
    }



}
