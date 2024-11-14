using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGame : MonoBehaviour
{
    [Header("GUI,real")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI cointText;
    [SerializeField] CanvasGroup PausePanel;
    [Header("GUI,GameOver")]
    [SerializeField] CanvasGroup GameOverPn;
    [SerializeField] TextMeshProUGUI scoreTextOV;
    [SerializeField] TextMeshProUGUI cointTextOV;
    [SerializeField] RawImage hscoreIcon;
    
    [Header("Source")]
    [SerializeField] ScoreManager score;
    [SerializeField] CoinManager coin;
    [SerializeField] GameState gameState;

    private void Awake()
    {
        PanelOnStart(PausePanel);
        PanelOnStart(GameOverPn);
    }
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver("ShowGameOver",ShowGameOver);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveFromObserver("ShowGameOver", ShowGameOver);
    }
    private void Update()
    {
        SetScoreText();
        SetCoinText();
    }

    void SetScoreText()
    {
        scoreText.text = string.Format(score.score.ToString());
    }

    void SetCoinText()
    {
        cointText.text = "x"+ coin.coin.ToString();
    }
    public void ShowPause()
    {
        ShowPanel(PausePanel);
        gameState.game = StateGame.pause;
        EventSystem.current.SetSelectedGameObject(null);
        SFXManager.Instance.PlayInputClip(1);
    }
    public void HidePause()
    {
        HidePanel(PausePanel);
        gameState.game = StateGame.process;
        EventSystem.current.SetSelectedGameObject(null);
        SFXManager.Instance.PlayInputClip(0);
    }

    void ShowGameOver()
    {
        ShowPanel(GameOverPn);
        scoreTextOV.text = string.Format("Score: {0}",score.score.ToString());
        cointTextOV.text = string.Format("Coin: {0}",coin.coin.ToString());
        if (hscoreIcon && score.score > score.highScore) 
        {
            hscoreIcon.DOFade(0f, 1f).SetUpdate(true)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InQuad);
        }
        else hscoreIcon.gameObject.SetActive(false);
    }
    void ShowPanel(CanvasGroup canvasgroup)
    {
        canvasgroup.alpha = 0f;
        canvasgroup.DOFade(1f, 0.2f).SetUpdate(true).OnComplete(() =>
        {
            canvasgroup.interactable = true;
            canvasgroup.blocksRaycasts = true;
        });
        
    }

    void HidePanel(CanvasGroup canvasgroup)
    {
        canvasgroup.alpha = 1f;
        canvasgroup.DOFade(0f, 0.2f).OnComplete(() =>
        {
            canvasgroup.interactable = false;
            canvasgroup.blocksRaycasts = false;
        });
    }

    void PanelOnStart(CanvasGroup cv)
    {
        cv.alpha = 0f;
        cv.interactable = false;
        cv.blocksRaycasts = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        SFXManager.Instance.PlayInputClip(1);
    }

    public void ReplayButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
        SFXManager.Instance.PlayInputClip(1);
    }
}
