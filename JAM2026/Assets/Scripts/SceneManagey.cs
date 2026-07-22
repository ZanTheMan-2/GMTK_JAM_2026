using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagey : MonoBehaviour
{
    public Stats stats;

    void SwitchScene(Scene scene)
    {
        //Animation
        stats.SceneSwitched();
        SceneManager.LoadScene(scene.name);
    }
}
