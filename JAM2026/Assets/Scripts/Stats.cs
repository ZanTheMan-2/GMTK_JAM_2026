using UnityEngine;

public class Stats : MonoBehaviour
{
    public int starterEnergy, starterHealth, starterTime;
    public int currentEnergy, currentHealth, currentTime;
    public SceneManagey sceneManager;

    // Activates when new scene is loaded
    void OnAwake()
    {
        if (PlayerPrefs.GetInt("statsExist") != 0)
        {
            currentEnergy = PlayerPrefs.GetInt("Energy");
            currentHealth = PlayerPrefs.GetInt("Health");
            currentTime = PlayerPrefs.GetInt("Time");
        }
        else
        {
            PlayerPrefs.SetInt("statsExist", 1);
            PlayerPrefs.SetInt("Energy", starterEnergy);
            PlayerPrefs.SetInt("Health", starterHealth);
            PlayerPrefs.SetInt("Time", starterTime);
        }
    }

    // Called whenever the scene is changed
    public void SceneSwitched()
    {
        PlayerPrefs.SetInt("Energy", currentEnergy);
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Time", currentTime);
    }

    void Update()
    {
        //Update meters or whatever here + change stats
    }
}
