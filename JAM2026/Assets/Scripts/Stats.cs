using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int starterEnergy, starterHealth, starterTime, starterCash;
    public int currentEnergy, currentHealth, currentTime, currentCash;
    public SceneManagey sceneManager;
    public Slider energy, health;
    public TextMeshProUGUI moneyText;

    void Awake()
    {
        Debug.Log($"{gameObject.scene.name}: starter={starterEnergy} current={currentEnergy} exists={PlayerPrefs.GetInt("statsExist", 0)}");
        if (PlayerPrefs.GetInt("statsExist", 0) != 0)
        {
            currentEnergy = PlayerPrefs.GetInt("Energy");
            currentHealth = PlayerPrefs.GetInt("Health");
            currentTime   = PlayerPrefs.GetInt("Time");
            currentCash   = PlayerPrefs.GetInt("Cash");
        }
        else
        {
            currentEnergy = starterEnergy;
            currentHealth = starterHealth;
            currentTime   = starterTime;
            currentCash   = starterCash;

            PlayerPrefs.SetInt("statsExist", 1);
            SceneSwitched();
        }
    }

    // Called whenever the scene is changed
    public void SceneSwitched()
    {
        PlayerPrefs.SetInt("Cash", currentCash);
        PlayerPrefs.SetInt("Energy", currentEnergy);
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Time", currentTime);
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