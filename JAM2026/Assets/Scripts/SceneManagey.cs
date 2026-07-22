using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagey : MonoBehaviour
{
    public Stats stats;

    public void SwitchScene(String scene)
    {
        //Animation
        stats.SceneSwitched();
        SceneManager.LoadScene(scene);
    }
}
