using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    [Header("Hp관련")]
    [SerializeField] Slider hpBar;

    [Header("인터렉션 소개UI")]
    [SerializeField] GameObject descriptionUi;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI descrip;

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
        descrip.text = itemData.description;
    }


}
