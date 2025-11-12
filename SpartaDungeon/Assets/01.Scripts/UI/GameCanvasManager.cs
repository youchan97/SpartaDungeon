using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    UiManager uiManager;
    GameManager gameManager;

    [Header("Hp관련")]
    [SerializeField] Slider hpBar;

    [Header("인터렉션 소개UI")]
    [SerializeField] GameObject descriptionUi;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI descrip;

    [Header("메뉴")]
    public GameObject menuPopup;

    private void Start()
    {
        uiManager = UiManager.Instance;
        uiManager.gameCanvasManager = this;
        gameManager = GameManager.Instance;
    }

    public void UpdateHpBar(Player player)
    {
        hpBar.value = player.Hp / player.MaxHp;
        if (hpBar.value <= 0)
        {
            hpBar.fillRect.gameObject.SetActive(false);
        }
    }


    public void ItemDescription(Item item, bool isOn = true)
    {
        if(isOn == false && descriptionUi.activeSelf)
        {
            descriptionUi.SetActive(false);
            return;
        }

        if (item == null) return;
        ItemScriptable itemData = item.ItemData;
        descriptionUi.gameObject.SetActive(true);
        title.text = itemData.itemName;
        descrip.text = string.Format("설명 : {0}", itemData.description);
    }

    public void OpenOptionPanel()
    {
        uiManager.OpenOptionPanel();
    }

    public void OnClickRestartButton()
    {
        gameManager.RestartGame();
    }

    public void OpenMenu()
    {
        gameManager.PauseGame();
        menuPopup.SetActive(true);
    }

    public void CloseMenu()
    {
        gameManager.ResumeGame();
        if (uiManager.OptionPanel.activeSelf)
            uiManager.OptionPanel.SetActive(false);
        menuPopup.SetActive(false);
    }
}
