using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] List<GameObject> playerGrid = new();

    private void Start()
    {
        SetStart();
        SetButton();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
    void InputChoose(int index)
    {
        foreach(var grid in playerGrid)
        {
            GameObject mark = grid.transform.Find("mark").gameObject;
            GameObject butt = grid.transform.Find("chooseButt").gameObject;
            mark.SetActive(false);
            CanvasGroup ca = butt.GetComponent<CanvasGroup>();
            ca.alpha = 1f;
            ca.blocksRaycasts = true;
            ca.interactable = true;
        }

        playerGrid[index].transform.Find("mark").gameObject.SetActive(true);

        CanvasGroup can = playerGrid[index].transform.Find("chooseButt").gameObject.GetComponent<CanvasGroup>();
        can.alpha = 0f;
        can.blocksRaycasts = false;
        can.interactable = false;
        PlayerPrefs.SetInt("choose", index);
        PlayerPrefs.Save();

    }

    void SetButton()
    {
        for (int i = 0; i < playerGrid.Count; i++)
        {
            int index = i;
            Button button = playerGrid[index].transform.Find("chooseButt").GetComponent<Button>();
            button.onClick.AddListener(() => InputChoose(index));
        }
    }

    void SetStart()
    {
        int chosen = PlayerPrefs.GetInt("choose", 0);
        InputChoose(chosen);
    }
}
