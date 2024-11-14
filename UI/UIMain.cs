using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIMain : MonoBehaviour
{
    [Header("game")]
    [SerializeField] Button shopButton;
    [SerializeField] Button settingButton;
    [Header("shop")]
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Button cancel;
    [SerializeField] CanvasGroup shop;

    [Header("Setting")]
    [SerializeField] CanvasGroup Setting;
    [SerializeField] Slider musicSlide;
    [SerializeField] Slider sfxSlide;
    [SerializeField] AudioSource mSource;
    [SerializeField] Button cancelSet;

    private void Start()
    {
        SetVolume("music", musicSlide, mSource);
        AudioSource sfx = SFXManager.Instance.transform.GetComponent<AudioSource>();
        SetVolume("sfx",sfxSlide, sfx);

        musicSlide.onValueChanged.AddListener(OnMusicChange);
        sfxSlide.onValueChanged.AddListener(OnSFXChange);
        Input();

    }
    private void Update()
    {
        SetCoin();
    }

    void Input()
    {
        settingButton.onClick.AddListener(() => ShowPanel(Setting));
        cancelSet.onClick.AddListener(() => HidePanel(Setting));
        shopButton.onClick.AddListener(() => ShowPanel(shop));
        cancel.onClick.AddListener(() => HidePanel(shop));
    }
    void OnMusicChange(float volume)
    {
        mSource.volume = volume;
        PlayerPrefs.SetFloat("music",volume);
        PlayerPrefs.Save();
    }

    void OnSFXChange(float volume)
    {
        AudioSource sfx = SFXManager.Instance.transform.GetComponent<AudioSource>();
        sfx.volume = volume;
        PlayerPrefs.SetFloat("sfx", volume);
        PlayerPrefs.Save();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        SFXManager.Instance.PlayInputClip(0);
    }
    void ShowPanel(CanvasGroup cv)
    {
        cv.alpha = 0f;
        cv.DOFade(1f, 0.2f).OnComplete(() =>
        {
            cv.interactable = true;
            cv.blocksRaycasts = true;
        });
        SFXManager.Instance.PlayInputClip(0);
    }

    void HidePanel(CanvasGroup cv)
    {
        cv.alpha = 1f;
        cv.DOFade(0f, 0.2f).OnComplete(() =>
        {
            cv.interactable = false;
            cv.blocksRaycasts = false;
        });
        SFXManager.Instance.PlayInputClip(1);
    }

    void SetVolume(string volume,Slider slider, AudioSource source)
    {
        float _volume = PlayerPrefs.GetFloat(volume, 1f);
        slider.value = _volume;
        source.volume = _volume;
    }

    void SetCoin()
    {
        int coin = PlayerPrefs.GetInt("coin", 0);
        coinText.text = string.Format(coin.ToString());
    }

    
}
