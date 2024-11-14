using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class LoadPlayerSelected : MonoBehaviour
{
    [SerializeField] List<AssetReference> playerList = new();
    Vector3 spawnPos = new Vector3(0, -2.11f, 11.94f);
    [SerializeField] GameObject loadScene;

    private void Awake()
    {
        Loading();
    }
    private void Start()
    {
        
    }
    private async Task LoadPlayer()
    {
        int playerIndex = PlayerPrefs.GetInt("choose", 0);
        if(playerIndex < 0 || playerIndex > playerList.Count)
        {
            Debug.Log("index not exist");
            return;
        }
        var handle = Addressables.LoadAssetAsync<GameObject>(playerList[playerIndex]);

        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result, spawnPos, Quaternion.identity);
            Debug.Log("load succed");
        }
        else Debug.LogError("loading fail");

    }

    public async void Loading()
    {
        loadScene.SetActive(true);
        await LoadPlayer();
        loadScene.SetActive(false);
    }
}
