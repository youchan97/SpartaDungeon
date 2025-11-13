using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ConstValue;

public class GameManager : SingletonManager<GameManager>
{
    public Player player;

    bool isPause;

    public bool IsPause { get => isPause; }


    public void PauseGame()
    {
        if (player == null || isPause) return;
        isPause = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        player.PausePlayer();
    }

    public void ResumeGame()
    {
        if (player == null || !isPause) return;
        isPause = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        player.ResumePlayer();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartGame()
    {
        if (player == null) return;
        isPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameSceneName);
    }

    public void GameOver()
    {
        PauseGame();
        player.Controller.PauseDisable();
    }
}
