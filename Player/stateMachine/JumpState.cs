using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirState
{
    public JumpState(Animator _anim, PlayerControl _control,
        PlayerHSM _hsm, PlayerGroundCheck _ground, PlayerStatus _status)
        : base(_anim, _control, _hsm, _ground, _status) { }

    public override void Enter()
    {
        base.Enter();
         anim.Play("jump");
    }
    
}
