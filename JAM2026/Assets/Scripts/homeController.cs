using UnityEngine;

public class homeController : MonoBehaviour
{
    public Stats stats;              // assign in Inspector
    public GameObject canva, gui;
    public dialogController con;
    public SpriteRenderer sprite;

    void Start()
    {
        if (stats.currentLandlord == 0)
        {
            stats.currentLandlord = 1;
            gui.SetActive(false);
            canva.SetActive(true);
            con.enabled = true;
            con.Begin();
        }
        else
        {
            gui.SetActive(true);
            canva.SetActive(false);
            sprite.enabled = false;
            con.enabled = false;
        }
    }
}