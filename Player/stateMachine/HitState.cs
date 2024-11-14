using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : StatePlayer
{
    public HitState(Animator _anim, PlayerControl _control,
        PlayerHSM _hsm, PlayerGroundCheck _ground, PlayerStatus _status)
        : base(_anim, _control, _hsm, _ground, _status) { }
    public override void Enter()
    {
        base.Enter();
        anim.Play("die",1,0f);
        anim.SetLayerWeight(1, 1);
        anim.speed = 1.2f;
        status.Hit = true;
    }
    public override void Exit()
    {
        base.Exit();
        anim.speed = 1;
        anim.SetLayerWeight(1, 0);
        //status.Hit = false;
        
    }
}
