using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagey : MonoBehaviour
{
    public Stats stats;
    public GameObject anim;
    public GameObject gui;

    public void SwitchScene(String scene)
{
    Debug.Log("SwitchScene called with: '" + scene + "'");

    if (gui != null) gui.SetActive(false);
    if (anim != null) anim.SetActive(true);

    StartCoroutine(waiter(scene));
}

IEnumerator waiter(String scene)
{
    yield return new WaitForSeconds(0.8f);
    Debug.Log("loading now: '" + scene + "'");
    stats.SceneSwitched();
    SceneManager.LoadScene(scene);
}
}