using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HomeButtons : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public Stats stats;
    public int sleepCost;
    public void eatButton()
    {
        
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
