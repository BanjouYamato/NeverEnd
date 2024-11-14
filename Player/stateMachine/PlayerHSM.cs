using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHSM : MonoBehaviour
{
    [SerializeField] StatePlayer state;
    
    public RunState runState;
    public SlideState slideState;
    public GroundState groundState;
    public AirState airState;
    public JumpState jumpState;
    public DownState downState;
    public HitState hitState;
    [SerializeField] PlayerStatus status;
    [SerializeField] PlayerControl player;
    [SerializeField] PlayerGroundCheck groundCheck;
    [SerializeField] Animator anim;

    private void Awake()
    {
        runState = new RunState(anim,player,this,groundCheck,status);
        slideState = new SlideState(anim, player, this, groundCheck, status);
        groundState = new GroundState(anim, player, this, groundCheck, status);
        airState = new AirState(anim, player, this, groundCheck, status);
        jumpState = new JumpState(anim, player, this, groundCheck, status);
        downState = new DownState(anim, player, this,groundCheck, status);
        hitState = new HitState(anim, player, this, groundCheck, status); 
    }
    private void Start()
    {
        ChangeState(runState);
    }
    private void Update()
    {
        state.Do();
    }
    public void ChangeState(StatePlayer _state)
    {
        if(state != null) state.Exit();
        state = _state;
        state.Enter();
    }
}
