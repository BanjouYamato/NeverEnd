using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
     int quantitySpawn = 2;
    Dictionary<string, List<Transform>> spawnPoint = new();
    private void Awake()
    {
        //spawnPoint.Add("side", new List<Transform>());
        //spawnPoint.Add("mid", new List<Transform>());
        spawnPoint["side"] = new List<Transform>();
        spawnPoint["mid"] = new List<Transform>();
        spawnPoint["coin"] = new();
        spawnPoint["item"] = new();

    }

    public void SpawnItemActive(string name, GameObject gameObject,Quaternion rotation)
    {
        spawnPoint[name].Clear();
        FindPoint(name, gameObject);
        if (spawnPoint[name].Count > 0)
        {
            int randomNumb = Random.Range(0, quantitySpawn);
            for (int i = 0; i < randomNumb; i++)
            {
                int randomPos = Random.Range(0, spawnPoint[name].Count);
                GameObject trap = CheckPool(name);
                if (trap)
                {
                    trap.transform.rotation = rotation;
                    trap.transform.position = spawnPoint[name][randomPos].position;
                    spawnPoint[name].RemoveAt(randomPos);
                }
                else
                {
                    Debug.LogError("null error");
                }
            }
        }
    }

    public void SpawnCoin(GameObject gameobj,Quaternion rotation)
    {
        spawnPoint["coin"].Clear();
        FindPoint("coin", gameobj);
        int randomAp = Random.Range(0, quantitySpawn);
        for (int i = 0; i < randomAp; i++)
        {
            int randomPos = Random.Range(0, spawnPoint["coin"].Count);
            GameObject coinLine = CoinPool.Instance.GetCoin();
            coinLine.transform.rotation = rotation;
            coinLine.transform.position = spawnPoint["coin"][randomPos].position;
            spawnPoint["coin"].RemoveAt(randomPos);          
        }

    }

    void FindPoint(string name, GameObject gameobject)
    {
        foreach (Transform child in gameobject.transform)
        {
            if (spawnPoint.ContainsKey(name))
            {
                if (child.CompareTag(name))
                    spawnPoint[name].Add(child);
            }
            else Debug.LogError("miss numb");
        }
    }

    GameObject CheckPool(string name)
    {
        switch (name)
        {
            case "side":
                return SpawnItemPool.Instance.GetItemSpawn("side", SpawnItemPool.Instance.sideTrap);
            case "mid":
                return SpawnItemPool.Instance.GetItemSpawn("mid", SpawnItemPool.Instance.staticTraps);
            case "item":
                return SpawnItemPool.Instance.GetItemSpawn("item", SpawnItemPool.Instance.skillItem);
            default:
                return null;
        }
    }

    public void SpawnAllItem(GameObject obj, Quaternion rotation)
    {
        SpawnCoin(obj,rotation);
        SpawnItemActive("side",obj,rotation);
        SpawnItemActive("mid", obj, rotation); 
        SpawnItemActive("item",obj,rotation);
    }
}
