using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject confirmationUI;
    public TextMeshProUGUI carEnergyText, carTimeText, walkEnergyText, walkHealthText, walkTimeText, locationText;
    int carEnergyCost, carTimeCost, walkEnergyCost, walkHealthGain, walkTimeCost;
    public SceneManagey sceneManager;
    public Stats stats;

    public void OnClick(MapObjects obj)
    {
        confirmationUI.SetActive(true);
        carEnergyText.SetText(obj.carEnergyCost.ToString());
        carTimeText.SetText(obj.carTimeCost.ToString());
        walkEnergyText.SetText(obj.walkEnergyCost.ToString());
        walkHealthText.SetText(obj.walkHealthGain.ToString());
        walkTimeText.SetText(obj.walkTimeCost.ToString());
        locationText.SetText(obj.locationName);
        carEnergyCost = obj.carEnergyCost;
        carTimeCost = obj.carTimeCost;
        walkEnergyCost = obj.walkEnergyCost;
        walkHealthGain = obj.walkHealthGain;
        walkTimeCost = obj.walkTimeCost;
    }

    public void Car()
    {
        stats.currentTime += carTimeCost;
        stats.currentEnergy -= carEnergyCost;
    }

    public void Walk()
    {
        stats.currentTime += walkTimeCost;
        stats.currentEnergy -= walkEnergyCost;
        stats.currentHealth += walkHealthGain;
    }

    public void No()
    {
        confirmationUI.SetActive(false);
    }
}
