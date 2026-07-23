using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;
public class FridgeButtons : MonoBehaviour
{
    public int saladPrice, burgerPrice, waterPrice,energyPrice;
    public int saladEnergy, saladHealth, burgerHealth, burgerEnergy,waterHealth, waterEnergy, energyEnergy, energyHealth;
    public TextMeshProUGUI errorText, burgerText, saladText, waterText, energyText;
   public GameObject houseGUI, bg;
   public Stats stats;

    private void Start()
    {
        bg.SetActive(true);
        houseGUI.SetActive(false);
        errorText.SetText(" ");
        burgerText.SetText($"Price {burgerPrice}\nHealth {burgerHealth}\nEnergy {burgerEnergy}");
        saladText.SetText($"Price {saladPrice}\nHealth {saladHealth}\nEnergy {saladEnergy}");
        waterText.SetText($"Price {waterPrice}\nHealth {waterHealth}\nEnergy {waterEnergy}");
        energyText.SetText($"Price {energyPrice}\nHealth {energyHealth}\nEnergy {energyEnergy}");


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
    public void waterBTN()
    {
        if(stats.currentCash > waterPrice)
        {
            stats.currentHealth += waterHealth;
            stats.currentEnergy += waterEnergy;
            stats.currentCash -= waterPrice;

        }
        else
        {
            errorText.SetText("Dont have enough money!");
        }
    }
    public void energyBTN()
    {
        if(stats.currentCash > energyPrice)
        {
            stats.currentHealth += energyHealth;
            stats.currentEnergy += energyEnergy;
            stats.currentCash -= energyPrice;

        }
        else
        {
            errorText.SetText("Dont have enough money!");
        }
    }
}
