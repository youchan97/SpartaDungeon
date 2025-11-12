using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : SingletonManager<UiManager>
{
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject exitPanel;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OpenOptionPanel()
    {
        gameManager.PauseGame();
        optionPanel.SetActive(true);
    }

    public void CloseOptionPanel()
    {
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
}
