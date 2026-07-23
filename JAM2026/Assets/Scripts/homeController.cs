using System;
using UnityEngine;

public class homeController : MonoBehaviour
{
    private Stats stats;
    public GameObject canva, gui;
    public dialogController con;
    void Start()
    {
        stats = GetComponent<Stats>();
        if(stats.currentLandlord ==0)
        {
            canva.SetActive(true);
            stats.currentLandlord = 1;
            return;
        } 
        gui.SetActive(true);
        con.enabled = false;
    }

   
}
