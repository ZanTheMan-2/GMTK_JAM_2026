using UnityEngine;
using TMPro;

public class Map : MonoBehaviour
{
    public GameObject confirmationUI;
    public TextMeshProUGUI carEnergyText, carTimeText, walkEnergyText,
                           walkHealthText, walkTimeText, locationText;
    public SceneManagey sceneManager;
    public Stats stats;

    private MapObjects selected;

    void Start()
    {
        confirmationUI.SetActive(false);
    }

    public void OnClick(MapObjects obj)
    {
        selected = obj;
        confirmationUI.SetActive(true);

        locationText.SetText($"Location: {obj.locationName}");
        carEnergyText.SetText($"Car energy cost: {obj.carEnergyCost.ToString()}");
        carTimeText.SetText($"Car time: {obj.carTimeCost.ToString()}");
        walkEnergyText.SetText($"Walk energy cost: {obj.walkEnergyCost.ToString()}");
        walkHealthText.SetText($"Walk Health gain: {obj.walkHealthGain.ToString()}");
        walkTimeText.SetText($"Walk time cost: {obj.walkTimeCost.ToString()}");
    }

    public void Car()
    {
        if (selected == null) return;
        if (stats.currentEnergy < selected.carEnergyCost)
        {
            Debug.Log("Not enough energy to drive");
            return;
        }

        stats.currentEnergy -= selected.carEnergyCost;
        stats.currentTime   += selected.carTimeCost;
        Travel();
    }

    public void Walk()
    {
        if (selected == null) return;
        if (stats.currentEnergy < selected.walkEnergyCost)
        {
            Debug.Log("Not enough energy to walk");
            return;
        }

        stats.currentEnergy -= selected.walkEnergyCost;
        stats.currentTime   += selected.walkTimeCost;
        stats.currentHealth += selected.walkHealthGain;
        Travel();
    }

    public void No()
    {
        confirmationUI.SetActive(false);
        selected = null;
    }

    private void Travel()
    {
        confirmationUI.SetActive(false);
        sceneManager.SwitchScene(selected.sceneName);
    }
}