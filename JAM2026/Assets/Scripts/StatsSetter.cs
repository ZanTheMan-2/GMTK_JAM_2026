using System.Runtime.CompilerServices;
using UnityEngine;

public class StatsSetter : MonoBehaviour
{
    public Stats stats;
    public int health, money, energy, time;
    void Start()
    {
        stats.currentHealth = health;
        stats.currentEnergy = energy;
        stats.currentCash = money;
        stats.currentTime = time;
        stats.retailApply = 0;
        stats.currentLandlord = 0;
    }
}
