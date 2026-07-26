using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HomeButtons : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public GameObject kitchenGUI, buttons, bg, homeButton;
    public Stats stats;
    public int sleepCost;

    private void Awake()
    {
        kitchenGUI.SetActive(false);
        if(stats.currentTime > 0)
        {
            homeButton.SetActive(false);
            return;
        }
        homeButton.SetActive(true);
    }
    public void eatButton()
    {
        bg.SetActive(true);
        kitchenGUI.SetActive(true);
        buttons.SetActive(false);
    }
    public void sleepButton()
    {   
            stats.currentDays += 1;
            stats.currentTime = 0;
            homeButton.SetActive(true);
            stats.currentEnergy +=5;
            stats.currentCash -= sleepCost;
            if(stats.currentEnergy > 10) stats.currentEnergy = 10;
        
    }
    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }
    public void pcButton()
    {
        sceneManagey.SwitchScene("Pc");
    }
}
