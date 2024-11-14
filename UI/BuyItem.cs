using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] Button buyButton;
    string stat;
    public enum PurchaseState
    {
        _notPurchased,
        purchased
    }
    public PurchaseState state;
    private void Awake()
    {
        buyButton = transform.Find("BuyButt").gameObject.GetComponent<Button>();
    }
    private void Start()
    {
        state = PurchaseState._notPurchased;
        buyButton.onClick.AddListener(Buy);
        stat = PlayerPrefs.GetString("stat", "none");
        ItemStat();
    }
    private void Update()
    {
        CheckPurchase();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            state = PurchaseState.purchased;
        }
    }
    void CheckPurchase()
    {
        switch (state)
        {
            case PurchaseState._notPurchased:
                NotBuy();
                break;
            case PurchaseState.purchased:
                Purchased();
                break;
            default:
                break;
        }
    }

    void NotBuy()
    {
        GameObject hide = gameObject.transform.Find("hide").gameObject;
        hide.SetActive(true);
        GameObject buy = gameObject.transform.Find("BuyButt").gameObject;
        buy.SetActive(true);
        GameObject chose = gameObject.transform.Find("chooseButt").gameObject;
        chose.SetActive(false);
    }

    void Purchased()
    {
        GameObject hide = gameObject.transform.Find("hide").gameObject;
        hide.SetActive(false);
        GameObject buy = gameObject.transform.Find("BuyButt").gameObject;
        buy.SetActive(false);
        GameObject chose = gameObject.transform.Find("chooseButt").gameObject;
        chose.SetActive(true);
    }

    public void Buy()
    {
        int coin = TotalCoin.Instance.totalCoin;
        if (state == PurchaseState._notPurchased
            && coin >= value)
        {
            state = PurchaseState.purchased;
            coin -= value;
            TotalCoin.Instance.UpdateCoin(coin);
            SFXManager.Instance.PlayInputClip(1);
            stat = "done";
            PlayerPrefs.SetString("stat",stat);
            PlayerPrefs.Save();
        }
        else SFXManager.Instance.PlayInputClip(0);
    }

    void ItemStat()
    {
        switch(stat)
        {
            case "none":
               state = PurchaseState._notPurchased;
               break;
            case "done":
                state = PurchaseState.purchased;
                break;
            default:
                break;
        }
    }
}
