using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemPool : MonoBehaviour
{
    public static SpawnItemPool Instance { get; private set; }

    public List<GameObject> staticTraps = new();
    public List<GameObject> sideTrap = new();
    public List<GameObject> skillItem = new();

    Dictionary<string, List<GameObject>> spawnItem = new();
    int quantitySpawn = 5;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AddToPool("mid",staticTraps);
        AddToPool("side",sideTrap);
        AddToPool("item",skillItem);
    }
    void AddToPool(string name, List<GameObject> list)
    {
        if (!spawnItem.ContainsKey(name))
        {
            spawnItem.Add(name, new List<GameObject>());
        }
        foreach(var item in list)
        {
            for (int i = 0; i < quantitySpawn; i++)
            {
                GameObject clone = Instantiate(item);
                spawnItem[name].Add(clone);
                clone.SetActive(false);
                clone.transform.parent = transform;
            }
        }
    }
    

    public GameObject GetItemSpawn(string name, List<GameObject> list)
    {
        if (!spawnItem.ContainsKey(name))
        {
            AddToPool(name, list);         
        }
        else
        {
            int maxTry = 5;
            int tryNumb = 0;
            while (tryNumb < maxTry)
            {
                int random = Random.Range(0, spawnItem[name].Count);
                GameObject selected = spawnItem[name][random];
                if (!selected.activeInHierarchy)
                {
                    selected.SetActive(true);
                    return selected;
                }
                tryNumb++;
            }
        }
        GameObject newClone = Instantiate(list[Random.Range(0,list.Count)]);
        spawnItem[name].Add(newClone);
        newClone.SetActive(true);
        newClone.transform.parent = transform;
        return newClone;
    }
}
