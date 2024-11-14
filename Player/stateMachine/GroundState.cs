using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundState : StatePlayer
{
    public GroundState(Animator _anim, PlayerControl _control,
        PlayerHSM _hsm, PlayerGroundCheck _ground, PlayerStatus _status)
        : base(_anim, _control, _hsm, _ground, _status) { }

    public override void Do()
    {
        base.Do();
        if (gcheck.isGround && !status.Hit)
        {
            if (control.slideTrigger)
            {
                hsm.ChangeState(hsm.slideState);
            }
            else if (!control.slideTrigger)
            {
                hsm.ChangeState(hsm.runState);
            }
        }
        else if (!gcheck.isGround && !status.Hit)
        {
            hsm.ChangeState(hsm.airState);
        }
        
    }
}
