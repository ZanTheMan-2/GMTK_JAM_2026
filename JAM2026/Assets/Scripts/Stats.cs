using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int starterEnergy, starterHealth, starterTime, starterCash, starterRetailApply, starterLandlord, starterBadEnding, starterHospitalEnding, starterHomelessEnding, starterGameEnd, starterBarPoints;
    public int currentEnergy, currentHealth, currentTime, currentCash, retailApply, currentLandlord, currentBadEnding, currentHospitalEnding, currentHomelessEnding,currentGameEnd, currentBarPoints;
    public SceneManagey sceneManager;
    public Slider energy, health;
    public TextMeshProUGUI moneyText;
   

    void Awake()
    {
        Debug.Log($"{gameObject.scene.name}: starter={starterEnergy} current={currentEnergy} exists={PlayerPrefs.GetInt("statsExist", 0)}");
        if (PlayerPrefs.GetInt("statsExist", 0) != 0)
        {
            currentBarPoints = PlayerPrefs.GetInt("BarPoints");
            currentGameEnd = PlayerPrefs.GetInt("GameEnd");
            currentHomelessEnding = PlayerPrefs.GetInt("HomelessEnding");
            currentHospitalEnding = PlayerPrefs.GetInt("HosptalEnding");
            currentBadEnding = PlayerPrefs.GetInt("BadEnding");
            currentEnergy = PlayerPrefs.GetInt("Energy");
            currentHealth = PlayerPrefs.GetInt("Health");
            currentTime   = PlayerPrefs.GetInt("Time");
            currentCash   = PlayerPrefs.GetInt("Cash");
            retailApply = PlayerPrefs.GetInt("retailApply");
            currentLandlord = PlayerPrefs.GetInt("LandLord");
        }
        else
        {
            currentBarPoints = starterBarPoints;
            currentGameEnd = starterGameEnd;
            currentHomelessEnding = starterHomelessEnding;
            currentHospitalEnding = starterHospitalEnding;
            currentBadEnding = starterBadEnding;
            currentEnergy = starterEnergy;
            currentHealth = starterHealth;
            currentTime   = starterTime;
            currentCash   = starterCash;
            retailApply = starterRetailApply;
            currentLandlord = starterLandlord;

            PlayerPrefs.SetInt("statsExist", 1);
            SceneSwitched();
        }
    }

    // Called whenever the scene is changed
    public void SceneSwitched()
    {
        PlayerPrefs.SetInt("BarPoints", currentBarPoints);
        PlayerPrefs.SetInt("GameEnd", currentGameEnd);
        PlayerPrefs.SetInt("HomelessEnding", currentHomelessEnding);
        PlayerPrefs.SetInt("HosptalEnding", currentHospitalEnding);
        PlayerPrefs.SetInt("BadEnding", currentBadEnding);
        PlayerPrefs.SetInt("Cash", currentCash);
        PlayerPrefs.SetInt("Energy", currentEnergy);
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Time", currentTime);
        PlayerPrefs.SetInt("retailApply", retailApply);
        PlayerPrefs.SetInt("LandLord", currentLandlord);
        PlayerPrefs.Save();
    }

    void Update()
    {
        Debug.Log($"hasKey={PlayerPrefs.HasKey("Energy")} stored={PlayerPrefs.GetInt("Energy", -999)} starter={starterEnergy} current={currentEnergy}");
        moneyText.SetText(currentCash.ToString());
        Debug.Log(currentEnergy);
        energy.value = currentEnergy;
        health.value = currentHealth;
    }
    
}