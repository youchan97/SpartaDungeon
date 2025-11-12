using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    public Player player;

    bool isPause;

    public bool IsPause { get => isPause; }


    public void PauseGame()
    {
        if (player == null) return;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (player == null) return;
        Time.timeScale = 1f;

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
