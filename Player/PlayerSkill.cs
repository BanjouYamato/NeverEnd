using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill Instance {  get; private set; }
    PlayerControl control;
    [SerializeField] float BonusSpeed;
    [SerializeField] float saveSpeed;
    [SerializeField] float saveForce;
    float timeSkill = 8f;
    [SerializeField] GameObject modelPrefab;
    [SerializeField] Color jumpColor;
    [SerializeField] Color speedColor;
    [SerializeField] Color x2Color;
    [SerializeField] Color defaultColor;
    public bool speedUp;
    bool forceUp;
    
    private void Awake()
    {
        Instance = this;
        control = GetComponent<PlayerControl>();
    }
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver("jumpSkill",JumpSkill);
        ObserverManager.Instance.RegisterObserver("speedSkill",SpeedSkill);
        ObserverManager.Instance.RegisterObserver("x2Score", X2Skill);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("jumpSkill", JumpSkill);
        ObserverManager.Instance.RemoveFromObserver("speedSkill", SpeedSkill);
        ObserverManager.Instance.RemoveFromObserver("x2Score", X2Skill);
    }

    private void Update()
    {
        SpeedNormal();
        ForceNormal();
    }
    void JumpSkill()
    {
        StartCoroutine(HighJump());
    }
    IEnumerator HighJump()
    {
        forceUp = true;
        ChangeColor(jumpColor);
        PlayerControl.Instance.jumpForce = saveForce;
        PlayerControl.Instance.jumpForce = saveForce * 2;
        
        yield return new WaitForSeconds(timeSkill);
        forceUp = false;
        ChangeColor(defaultColor);
        PlayerControl.Instance.jumpForce = saveForce;
    }

    void SpeedSkill()
    {
        StartCoroutine(SpeedBuff());
    }

    IEnumerator SpeedBuff()
    {
        speedUp = true;
        PlayerControl.Instance.moveSpeed = saveSpeed;
        PlayerControl.Instance.moveSpeed = saveSpeed * 2;
        ChangeColor(speedColor);
        ChangeLayer("invisible");
        yield return new WaitForSeconds(timeSkill);
        ChangeColor(defaultColor);
        ChangeLayer("Default");
        PlayerControl.Instance.moveSpeed = saveSpeed;
        speedUp = false;
    }

    void X2Skill()
    {
        StartCoroutine(BonusBuff());
    }

    IEnumerator BonusBuff()
    {
        ChangeColor(x2Color);
        yield return new WaitForSeconds(timeSkill);
        ChangeColor(defaultColor);
    }

    void ChangeColor(Color color)
    {
        foreach (Transform child in modelPrefab.transform)
        {
            Renderer childColor = child.GetComponent<Renderer>();
            if(childColor != null)
            {
                childColor.material.color = color;
            }
        }
    }

    void ChangeLayer(string layer)
    {
        gameObject.layer = LayerMask.NameToLayer(layer);
    }

    void SpeedNormal()
    {
        if (!speedUp)
        {
            saveSpeed = PlayerControl.Instance.moveSpeed;
        }
    }
    void ForceNormal()
    {
        if (!forceUp)
        {
            saveForce = PlayerControl.Instance.jumpForce;
        }
    }
}
