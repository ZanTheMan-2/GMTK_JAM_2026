using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class dialogController : MonoBehaviour
{
    private bool waited = false;
    public bool swapScene = false;
    public String sceneName;
    public AudioSource audioSource;
    public SceneManagey sceneManagey;
    public String[] text;
    public String[] whoIsTalking;
    public Sprite[] person;
    public AudioClip[] voice;
    public TextMeshProUGUI achualText, whoIsTalkingText;
    public GameObject canva, gui;
    public SpriteRenderer spriteRenderer;

    private int pos = 0;
    private bool finished = false;

    private void Start()
    {
        canva.SetActive(true);
        gui.SetActive(false);
        StartCoroutine(waiter());
    }

    private void Update()
    {
        if (!waited) return;
        if (finished) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (pos >= text.Length)
        {
            finished = true;

            if (swapScene)
            {
                sceneManagey.SwitchScene(sceneName);
            }
            else
            {
                canva.SetActive(false);
                gui.SetActive(true);
            }
            return;
        }

        achualText.SetText(text[pos]);
        whoIsTalkingText.SetText(whoIsTalking[pos]);
        spriteRenderer.sprite = person[pos];
        audioSource.PlayOneShot(voice[pos]);
        pos++;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.4f);
        waited = true;
    }
}