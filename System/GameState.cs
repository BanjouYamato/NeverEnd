using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    process,
    pause,
    end
}
public class GameState : MonoBehaviour
{
   public StateGame game;

    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("GameOver", GameOver);
    }
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver("GameOver", GameOver);
        game = StateGame.process;
    }
    private void Update()
    {
        CheckStateGame();
    }
    void CheckStateGame()
    {
        switch (game)
        {
            case StateGame.process:
                OnProcesscing(); break;
            case StateGame.pause:
                OnPauseState(); break;
            case StateGame.end:
                OnGameOver(); break;
            default:
                break;
        }
    }

    void OnProcesscing()
    {
        Time.timeScale = 1;
    }

    void OnPauseState()
    {
        Time.timeScale = 0;
    }

    void OnGameOver()
    {
        StartCoroutine(WaitEnd());
    } 

    IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        ObserverManager.Instance.TriggerAction("ShowGameOver");
    }

    void GameOver()
    {
        game = StateGame.end;
    }
}
