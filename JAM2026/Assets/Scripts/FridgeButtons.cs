using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;
public class FridgeButtons : MonoBehaviour
{
    public int saladPrice, burgerPrice;
    public int saladEnergy, saladHealth, burgerHealth, burgerEnergy;
    public TextMeshProUGUI errorText, burgerText, saladText;
   public GameObject houseGUI, bg;
   public Stats stats;

    private void Start()
    {
        bg.SetActive(true);
        houseGUI.SetActive(false);
        errorText.SetText(" ");
        burgerText.SetText($"Price {burgerPrice}\nHealth {burgerHealth}\nEnergy {burgerEnergy}");
        saladText.SetText($"Price {saladPrice}\nHealth {saladHealth}\nEnergy {saladEnergy}");
    }
    public void leaveButton()
    {
        houseGUI.SetActive(true);
        bg.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void burgerButton()
    {
        if(stats.currentCash > burgerPrice)
        {
            stats.currentHealth += burgerHealth;
            stats.currentEnergy += burgerEnergy;
            stats.currentCash -= burgerPrice;
            Debug.Log("bruger");
        }
        else
        {
            errorText.SetText("Dont have enough money!");
        }
    }
    public void saladButton()
    {
        if(stats.currentCash > saladPrice)
        {
            stats.currentHealth += saladHealth;
            stats.currentEnergy += saladEnergy;
            stats.currentCash -= saladPrice;

        }
        else
        {
            errorText.SetText("Dont have enough money!");
        }
    }
}
