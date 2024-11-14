using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool Hit {  get; set; }
    [SerializeField] PlayerHSM hsm;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            //StartCoroutine(HitEffect());
            hsm.ChangeState(hsm.hitState);
            SFXManager.Instance.PlayPlayerClip(2);
            SFXManager.Instance.PlayPlayerClip(3);
            ObserverManager.Instance.TriggerAction("GameOver");
        }
    }

    IEnumerator HitEffect()
    {
        Hit = true;
        yield return null;
        Hit = false;
        //yield return new WaitForSeconds(1.15f);
        
    }



    
}
