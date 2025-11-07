using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] Slider hpBar;


    public void UpdateHpBar(Player player)
    {
        hpBar.value = player.Hp / player.MaxHp;
        if (hpBar.value <= 0)
        {
            hpBar.fillRect.gameObject.SetActive(false);
        }
    }



}
