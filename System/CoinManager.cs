using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public int coin;
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver("coin", CoinPlus);
        ObserverManager.Instance.RegisterObserver("GameOver", CoinOver );
    }

    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("coin", CoinPlus);
        ObserverManager.Instance.RemoveFromObserver("GameOver", CoinOver);
    }

    void CoinPlus()
    {
        coin++;
    }

    void CoinOver()
    {
        int coinNow = PlayerPrefs.GetInt("coin", 0);
        int newCoin = coin + coinNow;
        PlayerPrefs.SetInt("coin",newCoin);
        PlayerPrefs.Save();
        Debug.Log("nhung");
    }
}
