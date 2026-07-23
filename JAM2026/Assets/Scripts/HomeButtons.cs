using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HomeButtons : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public GameObject kitchenGUI, buttons, bg;
    public Stats stats;
    public int sleepCost;

    private void Awake()
    {
        kitchenGUI.SetActive(false);
    }
    public void eatButton()
    {
        bg.SetActive(true);
        kitchenGUI.SetActive(true);
        buttons.SetActive(false);
    }
    public void sleepButton()
    {
        if(stats.currentEnergy < 10)
        {
            stats.currentEnergy +=5;
            stats.currentCash -= sleepCost;
            if(stats.currentEnergy > 10) stats.currentEnergy = 10;
        }
    }
    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }
}
