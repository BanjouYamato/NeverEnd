using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : StatePlayer
{
    public AirState(Animator _anim, PlayerControl _control, 
        PlayerHSM _hsm, PlayerGroundCheck _ground, PlayerStatus _status)
        : base(_anim, _control, _hsm, _ground, _status) { }

    public override void Do()
    {
        base.Do();
        if (gcheck.isGround) hsm.ChangeState(hsm.groundState);
        else
        {
            if (control.fastFall) hsm.ChangeState(hsm.downState);
             else hsm.ChangeState(hsm.jumpState);
            
        }
       
    }
    public override void Exit()
    {
        base.Exit();
    }
}
