using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : SingletonManager<UiManager>
{
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject exitPanel;

    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider effectSlider;

    GameManager gameManager;
    SoundManager soundManager;

    public GameCanvasManager gameCanvasManager;

    public GameObject OptionPanel { get => optionPanel; }

    private void Start()
    {
        gameManager = GameManager.Instance;
        soundManager = SoundManager.Instance;
    }


    public void OpenOptionPanel()
    {
        if(!gameManager.IsPause)
            gameManager.PauseGame();
        optionPanel.SetActive(true);
    }

    public void CloseOptionPanel()
    {
        if(gameManager.IsPause && !gameCanvasManager.menuPopup.activeSelf)
            gameManager.ResumeGame();
        optionPanel.SetActive(false);
    }
    public void OpenExitPanel()
    {
        gameManager.PauseGame();
        exitPanel.SetActive(true);
    }

    public void CloseExitPanel()
    {
        gameManager.ResumeGame();
        exitPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        gameManager.ExitGame();
    }

    public void ChangeBgmVolumeSlider()
    {
        soundManager.ChangeBgmVolume(bgmSlider.value);
    }

    public void ChangeEffectVolumeSlider()
    {
        soundManager.ChangeEffectVolume(effectSlider.value);
    }
}
