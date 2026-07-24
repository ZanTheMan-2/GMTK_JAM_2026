using System.Runtime.CompilerServices;
using UnityEngine;

public class StatsSetter : MonoBehaviour
{
    public Stats stats;
    public int health, money, energy, time;
    void Start()
    {
        Debug.Log("stats seted");
        stats.currentGameEnd = 0;
         Debug.Log($"Current game end: {stats.currentGameEnd}");

        stats.currentHealth = health;
        stats.currentEnergy = energy;
        stats.currentCash = money;
        stats.currentTime = time;
        stats.retailApply = 0;
        stats.currentLandlord = 0;
        stats.currentLandlord = 0;
        stats.currentBarPoints = 0;
    }
}
