using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatePlayer 
{
    protected Animator anim;
    protected PlayerControl control;
    protected PlayerHSM hsm;
    protected PlayerGroundCheck gcheck;
    protected PlayerStatus status;
    public StatePlayer (Animator _anim, PlayerControl _control, PlayerHSM _hsm
        ,PlayerGroundCheck _ground, PlayerStatus _status)
    {
        this.anim = _anim;
        this.control = _control;
        this.hsm = _hsm;
        this.gcheck = _ground;
        this.status = _status;
    }
    public virtual void Enter() { }
    public virtual void Do()
    {
    }
    public virtual void Exit() { }
}
