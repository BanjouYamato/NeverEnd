using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public static CoinPool Instance {  get; private set; }
    [SerializeField] GameObject coin;
    [SerializeField] List<GameObject> coinList = new List<GameObject>();
    [SerializeField] int quantitySpawn = 10;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PoolCoin();
    }
    void PoolCoin()
    {
        for (int i = 0; i < quantitySpawn; i++)
        {
            GameObject coinClone = CoinLine();
            coinClone.SetActive(false);
            coinList.Add(coinClone);
            coinClone.transform.parent = transform;
        }

    }
    GameObject CoinLine()
    {
        GameObject coinLine = new GameObject("coinLine");
        coinLine.tag = "coinLine";
        BoxCollider box = coinLine.AddComponent<BoxCollider>();
        box.isTrigger = true;
        
            int randomQuan = Random.Range(3, 7);
            for (int i = 0; i < randomQuan; i++)
            {
                GameObject clone = Instantiate(coin);
                Vector3 offset = coinLine.transform.position +
                    new Vector3(0f, 0f, i * 1.5f);
                clone.transform.position = offset;
                clone.transform.parent = coinLine.transform;

            }
        
        return coinLine;
    }

    public GameObject GetCoin()
    {
        
        int tryNumb = 0;
        int maxTry = 5;
        while(tryNumb < maxTry)
        {
            int randomNumb = Random.Range(0, coinList.Count);
            GameObject obj = coinList[randomNumb];
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
           
        }
        GameObject coinLine = new GameObject("coinLine");
        int randomQuan = Random.Range(3, 7);
        for (int i = 0; i < randomQuan; i++)
        {
            GameObject clone = Instantiate(coin);
            Vector3 offset = coinLine.transform.position +
                new Vector3(0f, 0f, i * 1.5f);
            clone.transform.position = offset;
            clone.transform.parent = coinLine.transform;

        }
        coinLine.SetActive(false);
        coinList.Add(coinLine);
        return coinLine;
    }
}
