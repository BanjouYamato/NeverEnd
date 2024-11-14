using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownState : AirState
{
    public DownState(Animator _anim, PlayerControl _control,
        PlayerHSM _hsm, PlayerGroundCheck _ground, PlayerStatus _status)
        : base(_anim, _control, _hsm, _ground, _status) { }

    public override void Enter()
    {
        base.Enter();
        //anim.Play("Falling To Landing");
        anim.CrossFade("fall",0.2f);
    }
}
