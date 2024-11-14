using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPooling : MonoBehaviour
{
    public static MapPooling Instance {  get; private set; }
    [SerializeField] List<GameObject> sections = new();
    [SerializeField] List<GameObject> inActiveSection = new();

    private void Awake()
    {
        Instance = this;
        AddToPool();
    }


    public void AddToPool()
    {
        foreach (GameObject section in sections)
        {
            GameObject clone = Instantiate(section);
            inActiveSection.Add(clone);
            clone.SetActive(false);
            clone.transform.parent = transform;
        }
    }

    public GameObject GetSection()
    {
        int randomIndex = Random.Range(0, inActiveSection.Count);
        GameObject cloneSection = inActiveSection[randomIndex];
        cloneSection.SetActive(true);
        inActiveSection.RemoveAt(randomIndex);
        return cloneSection;
    }

    public void RemoveSection(GameObject clone)
    {
        clone.SetActive(false);
        inActiveSection.Add(clone);
    }

}
