using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoin : MonoBehaviour
{
    public static TotalCoin Instance {  get; private set; }

    public int totalCoin;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        totalCoin = PlayerPrefs.GetInt("coin", 0);
    }

    public void MoreCoin(int coin)
    {
        totalCoin += coin;
    }

    public void BuySomething(int coin)
    {
        totalCoin -= coin;
    }

    public void UpdateCoin(int newValue)
    {
        PlayerPrefs.SetInt("coin",newValue);
        PlayerPrefs.Save();
    }
}
