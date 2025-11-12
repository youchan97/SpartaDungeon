using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    UiManager uiManager;

    [Header("Hp관련")]
    [SerializeField] Slider hpBar;

    [Header("인터렉션 소개UI")]
    [SerializeField] GameObject descriptionUi;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI descrip;

    private void Start()
    {
        uiManager = UiManager.Instance;
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
        GameManager.Instance.RestartGame();
    }

}
