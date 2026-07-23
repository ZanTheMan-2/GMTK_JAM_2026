using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using JetBrains.Annotations;
public class tillController : MonoBehaviour
{
   [Header("Refs")]
    public Canvas canvas;
    public RectTransform spawnArea;      // left side
    public RectTransform scanZone;       // right side
    public RectTransform itemLayer;      // parent for spawned items
    public GameObject itemPrefab;

    [Header("UI")]
    public Slider timerSlider;
    public TextMeshProUGUI timerText, scoreText;
    public GameObject gamePanel, resultPanel, startShiftButton;
    public TextMeshProUGUI resultText;

    [Header("Game")]
    public float gameDuration = 30f;
    public float spawnInterval = 1.2f;
    public int maxOnScreen = 6;
    public int cashPerItem = 2;
    public int timeCost = 1;

    [Header("sound")]
    public AudioSource audioSource;
    public AudioClip scanSound;
    public Sprite[] itemSprites;
    public Stats stats;
    public SceneManagey sceneManagey;

    private float timeLeft;
    private float spawnTimer;
    private int score;
    private bool running;
    private readonly List<ScannableItem> live = new List<ScannableItem>();

    private void Start()
    {
        if (resultPanel != null) resultPanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    public void StartGame()
    {
        startShiftButton.SetActive(false);
        if (running) return;

        ClearItems();
        score = 0;
        timeLeft = gameDuration;
        spawnTimer = 0f;
        running = true;

        gamePanel.SetActive(true);
        if (resultPanel != null) resultPanel.SetActive(false);

        if (timerSlider != null) timerSlider.maxValue = gameDuration;
        UpdateHUD();
    }

    private void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            UpdateHUD();
            EndGame();
            return;
        }

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && live.Count < maxOnScreen)
        {
            SpawnItem();
            spawnTimer = spawnInterval;
        }

        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (timerSlider != null) timerSlider.value = timeLeft;
        if (timerText != null) timerText.SetText(Mathf.CeilToInt(timeLeft).ToString());
        if (scoreText != null) scoreText.SetText(score.ToString());
    }

    private void SpawnItem()
    {
        GameObject go = Instantiate(itemPrefab, itemLayer);

        ScannableItem item = go.GetComponent<ScannableItem>();
        item.game = this;
        item.canvas = canvas;

        Rect r = spawnArea.rect;
        Vector3 local = new Vector3(
            Random.Range(r.xMin, r.xMax),
            Random.Range(r.yMin, r.yMax),
            0f);
        go.transform.position = spawnArea.TransformPoint(local);

        if (itemSprites != null && itemSprites.Length > 0)
        {
            Image img = go.GetComponent<Image>();
            if (img != null) img.sprite = itemSprites[Random.Range(0, itemSprites.Length)];
        }

        live.Add(item);
    }

    public bool IsOverScanner(Vector2 screenPoint)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(
            scanZone, screenPoint, canvas.worldCamera);
    }

    public void ItemScanned(ScannableItem item)
    {
        if (!running) return;

        score++;
        live.Remove(item);
        Destroy(item.gameObject);

        if (audioSource != null && scanSound != null)
            audioSource.PlayOneShot(scanSound);

        UpdateHUD();
    }

    private void EndGame()
    {
        running = false;
        ClearItems();
        gamePanel.SetActive(false);

        if (stats != null)
        {
            stats.currentCash += score * cashPerItem;
            stats.currentTime += timeCost;
        }

        if (resultText != null)
            resultText.SetText($"Scanned {score} items\nEarned {score * cashPerItem}");

        if (resultPanel != null) resultPanel.SetActive(true);
    }

    private void ClearItems()
    {
        foreach (ScannableItem item in live)
        {
            if (item != null) Destroy(item.gameObject);
        }
        live.Clear();
    }
    public void leaveBTN()
    {
        sceneManagey.SwitchScene("Home");
    }
    public void CloseResult()
    {
        if (resultPanel != null) resultPanel.SetActive(false);
        if (sceneManagey != null) sceneManagey.SwitchScene("Map");
    }
}
