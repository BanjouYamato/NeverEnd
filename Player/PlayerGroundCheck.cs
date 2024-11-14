using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isGround = true;
    [SerializeField] PlayerStatus status;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = true;
            PlayerControl.Instance.fastFall = false;
            //SFXManager.Instance.PlayPlayerClip(2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = true;
            PlayerControl.Instance.fastFall = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) isGround = false;
    }
}
