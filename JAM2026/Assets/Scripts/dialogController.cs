using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class dialogController : MonoBehaviour
{
    [Tooltip("Untick for dialogues triggered by a button instead of on scene load.")]
    public bool beginOnStart = true;

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

    [Tooltip("Fires when the last line has been read. Leave empty if nothing needs it.")]
    public UnityEvent onFinished;

    private int pos = 0;

    public bool IsRunning { get; private set; }

    private void Start()
    {
        if (beginOnStart)
        {
            gui.SetActive(false);
            Begin();
        }
    }

    public void Begin()
    {
        if (text == null || text.Length == 0)
        {
            Debug.LogWarning($"{gameObject.name}: dialogue has no lines.");
            IsRunning = false;
            return;
        }

        pos = 0;
        waited = false;
        IsRunning = true;

        if (canva != null) canva.SetActive(true);
        spriteRenderer.enabled = true;

        StopAllCoroutines();
        StartCoroutine(waiter());
    }

    public void Restart() { Begin(); }

    private void Update()
    {
        if (!IsRunning) return;
        if (!waited) return;
        if (canva != null && !canva.activeInHierarchy) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (pos >= text.Length)
        {
            IsRunning = false;

            if (swapScene)
            {
                sceneManagey.SwitchScene(sceneName);
            }
            else
            {
                spriteRenderer.enabled = false;
                canva.SetActive(false);
                gui.SetActive(true);
            }

            if (onFinished != null) onFinished.Invoke();
            return;
        }

        achualText.SetText(text[pos]);
        whoIsTalkingText.SetText(whoIsTalking[pos]);

        if (pos < person.Length && person[pos] != null)
            spriteRenderer.sprite = person[pos];

        if (pos < voice.Length && voice[pos] != null)
            audioSource.PlayOneShot(voice[pos]);

        pos++;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.4f);
        waited = true;
    }
}