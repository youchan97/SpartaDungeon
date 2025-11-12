using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ConstValue;

public class StartCanvasManager : MonoBehaviour
{
    public void OnClickExitButton()
    {
        GameManager.Instance.ExitGame();
    }
    public void GameStart()
    {
        LoadingManager.LoadScene(GameSceneName);
    }
}
