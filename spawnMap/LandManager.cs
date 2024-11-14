using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    public static LandManager Instance { get; private set; }
    public GameObject startLand;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> activeSection;
    int landQuantity = 3;
    [SerializeField] SectionManager section;

    private void Start()
    {
        activeSection.Add(startLand);
        StartSpawnLand();
        ObserverManager.Instance.RegisterObserver("spawnMap",SpawnLand);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("spawnMap", SpawnLand); 
    }
    public void SpawnLand()
    {
        AddNewSection();
        Invoke(nameof(DestroySection), 1f);
    }
    void StartSpawnLand()
    {
        for (int i =0; i<landQuantity;i++)
        {
            GameObject clone = MapPooling.Instance.GetSection();
            float rotation = spawnPoint.transform.localEulerAngles.y;
            float yLast = activeSection[activeSection.Count-1].transform.localEulerAngles.y;
            Quaternion newRotation = Quaternion.Euler(0, rotation + yLast, 0);
            clone.transform.rotation = newRotation;
            Transform startPoint = clone.transform.Find("startPoint");      
            Vector3 offset = spawnPoint.position - startPoint.position;            
            clone.transform.position += offset;
            section.SpawnAllItem(clone, newRotation);
            spawnPoint = clone.transform.Find("spawnPoint");
            activeSection.Add(clone);
        }
    }
    void DestroySection()
    {
        MapPooling.Instance.RemoveSection(activeSection[0]);
        activeSection.RemoveAt(0);        
    }
    void AddNewSection()
    {
        GameObject newClone = MapPooling.Instance.GetSection();
        float rotation = spawnPoint.localEulerAngles.y;
        float yLast = activeSection[activeSection.Count-1].transform.localEulerAngles.y;
        Quaternion newRotate = Quaternion.Euler(0, rotation + yLast, 0);
        newClone.transform.rotation = newRotate;
        Vector3 startPoint = newClone.transform.Find("startPoint").position;
        spawnPoint = activeSection[activeSection.Count - 1].transform.Find("spawnPoint"); 
        Vector3 offset = spawnPoint.position - startPoint;    
        newClone.transform.position += offset;
        section.SpawnAllItem(newClone, newRotate);
        spawnPoint = newClone.transform.Find("spawnPoint");
        activeSection.Add(newClone);
    }
   
}
