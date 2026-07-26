using UnityEngine;
using TMPro;

public class homeController : MonoBehaviour
{
    public Stats stats;              // assign in Inspector
    public GameObject canva, gui;
    public dialogController con;
    public SpriteRenderer sprite;
    public TextMeshProUGUI texty;

    private void Update()
    {
        texty.SetText($"{stats.currentDays}");
    }
    private void Start()
    {
        stats.currentLandlord = 1;

        if (stats.currentLandlord == 0)
        {
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