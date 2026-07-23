using System;
using UnityEngine;
using TMPro;

public class dialogController : MonoBehaviour
{
    
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
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (pos >= text.Length)
        {
            if (finished) return;
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
}