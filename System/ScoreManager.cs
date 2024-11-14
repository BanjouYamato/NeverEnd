using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public int highScore;
    int bonusPoint = 1;
    [SerializeField] GameState gameState;
    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver("x2Score", BonusActive);
        ObserverManager.Instance.RegisterObserver("GameOver", SaveHighScore);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("x2Score", BonusActive);
        ObserverManager.Instance.RemoveFromObserver("GameOver", SaveHighScore);
    }
    private void Update()
    {
        if(gameState.game == StateGame.process)
        score += bonusPoint;
    }

    void BonusActive()
    {
        StartCoroutine(BonusEffect());
    }
    IEnumerator BonusEffect()
    {
        bonusPoint = 2;
        yield return new WaitForSeconds(8f);
        bonusPoint = 1;
    }

    void SaveHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
