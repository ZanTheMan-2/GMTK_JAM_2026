using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stats : MonoBehaviour
{
    public int starterEnergy, starterHealth, starterTime, starterCash;
    public int currentEnergy, currentHealth, currentTime, currentCash;
    public SceneManagey sceneManager;
    public Slider energy;
    public TextMeshProUGUI moneyText;
    // Activates when new scene is loaded
    void Awake()
    {
        if (PlayerPrefs.GetInt("statsExist") != 0)
        {
            currentEnergy = PlayerPrefs.GetInt("Energy");
            currentHealth = PlayerPrefs.GetInt("Health");
            currentTime = PlayerPrefs.GetInt("Time");
            currentCash = PlayerPrefs.GetInt("Cash");
        }
        else
        {
            PlayerPrefs.SetInt("statsExist", 1);
            PlayerPrefs.SetInt("Energy", starterEnergy);
            PlayerPrefs.SetInt("Health", starterHealth);
            PlayerPrefs.SetInt("Time", starterTime);
            PlayerPrefs.SetInt("Cash", starterCash);
        }
    }

    // Called whenever the scene is changed
    public void SceneSwitched()
    {
        PlayerPrefs.SetInt("Cash", currentCash);
        PlayerPrefs.SetInt("Energy", currentEnergy);
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Time", currentTime);
    }

    void Update()
    {
        moneyText.SetText(currentCash.ToString());
        energy.value = currentEnergy;
    }
}
