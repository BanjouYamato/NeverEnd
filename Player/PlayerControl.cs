using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }
    public float moveSpeed;
    Rigidbody rb;
    [SerializeField] float xInput;
    [SerializeField] PlayerGroundCheck ground;
    public float jumpForce;
    [SerializeField] CapsuleCollider bodyCol;
    [SerializeField] SphereCollider rollCol;
    public bool slideTrigger;
    public bool fastFall;
    [SerializeField] float fallSpeed = 13f;
    Vector3 currentDirection;
    Quaternion newRotation;
    PlayerStatus status;
    [SerializeField] GameState state;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        bodyCol = GetComponent<CapsuleCollider>();
        rollCol = GetComponent <SphereCollider>();
        status = GetComponent<PlayerStatus>();
    }
    private void Start()
    {
        bodyCol.enabled = true;
        rollCol.enabled = false;
        newRotation = transform.rotation;
        state = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
        ObserverManager.Instance.RegisterObserver("TurnRight",RightTurn);
        ObserverManager.Instance.RegisterObserver("TurnLeft",LeftTurn);
        ObserverManager.Instance.RegisterObserver("spawnMap", UpdateSpeed);
    }
    void Update()
    {
        moveSpeed = Mathf.Clamp(moveSpeed, 0f, 30f);
        jumpForce = Mathf.Clamp(jumpForce, 0f, 24f);
        currentDirection = transform.forward;
        if (state.game == StateGame.process)
        {
            CheckInput();
            JumpInput();
            Roll();
            CheckFall();
            FallDown();
        }
    }
    private void FixedUpdate()
    {
        if(!status.Hit)
        PlayerMove();
        
    }
    void PlayerMove()
    {
        Vector3 movePos =  currentDirection * moveSpeed * Time.fixedDeltaTime;
        Vector3 horizontlMove = Vector3.Cross(currentDirection, Vector3.up) * -xInput *moveSpeed * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + horizontlMove + movePos;
        rb.MovePosition(newPos);
    }
    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        SFXManager.Instance.PlayPlayerClip(0);
    }

    void JumpInput()
    {
        if (Input.GetButtonDown("Jump") && ground.isGround && !status.Hit)
        {
            Jump();
        }
    }

    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.Z) && ground.isGround && !slideTrigger && !status.Hit )
        {
            StartCoroutine(Rolling());
            SFXManager.Instance.PlayPlayerClip(4);
        }
    }

    IEnumerator Rolling()
    {
        slideTrigger = true;
        bodyCol.enabled = false;
        rollCol.enabled = true;
        yield return new WaitForSeconds(1f);
        bodyCol.enabled = true;
        rollCol.enabled=false;
        slideTrigger = false;
    }
    void CheckFall()
    {
        if(rb.velocity.y < 0 && !ground.isGround)
        {
            GravityFall(5f);
        }
    }
    void FallDown()
    {
        if(!ground.isGround && Input.GetKeyDown(KeyCode.Z))
        {
            rb.velocity = new Vector3(rb.velocity.x,-fallSpeed,rb.velocity.z);
            fastFall = true;
        }
    }
    void GravityFall(float gravityMulti)
    {
        rb.AddForce(Vector3.up * Physics.gravity.y * gravityMulti * Time.deltaTime,ForceMode.Impulse);
    }
    
    void RightTurn()
    {
        Quaternion rightTurn = Quaternion.Euler(0, 90, 0);
        newRotation *= rightTurn;
        RotateTo(newRotation, 0.5f);
    }

    void LeftTurn()
    {
        Quaternion leftTurn = Quaternion.Euler(0,-90,0);
        newRotation *= leftTurn;
        RotateTo(newRotation, 0.5f);
    }

    void RotateTo(Quaternion rotation, float duration)
    {
        transform.DORotateQuaternion(rotation,duration);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("TurnRight",RightTurn);
        ObserverManager.Instance.RemoveFromObserver("TurnLeft",LeftTurn);
        ObserverManager.Instance.RemoveFromObserver("spawnMap", UpdateSpeed);
    }

     void UpdateSpeed()
    {
        moveSpeed += 0.5f;
    }
}
