using UnityEngine;
using TMPro;

[System.Serializable]
public class AlleyEncounter
{
    [TextArea(2, 4)] public string prompt;
    public string option1Label;
    public string option2Label;

    [TextArea(2, 4)] public string option1Result;
    [TextArea(2, 4)] public string option2Result;

    public int cashChange, healthChange, energyChange;

    public bool option2SwitchesScene;
    public string sceneToLoad;
}

public class AlleyController : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public Stats stats;

    public GameObject mainCanvas;      // explore button screen
    public GameObject textCanvas;      // the text box
    public GameObject buttonsCanvas;   // the two option buttons
    public TextMeshProUGUI option1Text, option2Text, textBoxText;
    public TextMeshProUGUI mainMessageText;   // sits on mainCanvas

    public AlleyEncounter[] encounters;
    public int exploreCost = 1;

    private bool showingResult = false;
    private string pendingScene = null;

    private void Start()
    {
        textCanvas.SetActive(false);
        buttonsCanvas.SetActive(false);
    }

    private void Update()
    {
        if (showingResult && Input.GetKeyDown(KeyCode.Space))
        {
            showingResult = false;
            textCanvas.SetActive(false);
            mainCanvas.SetActive(true);

            if (pendingScene != null)
            {
                stats.currentGoodEnd = 1;
                sceneManagey.SwitchScene(pendingScene);
                pendingScene = null;
                return;
            }

            stats.currentAlley++;
        }
    }

    public void exploreButton()
    {
        if (showingResult) return;

        int i = stats.currentAlley;

        if (i >= encounters.Length)
        {
            mainMessageText.SetText("There's nothing left down here.");
            return;
        }

        if (stats.currentEnergy < exploreCost)
        {
            mainMessageText.SetText("You're too exhausted to explore.");
            return;
        }

        stats.currentEnergy -= exploreCost;
        mainMessageText.SetText("");

        AlleyEncounter e = encounters[i];
        textBoxText.SetText(e.prompt);
        option1Text.SetText(e.option1Label);
        option2Text.SetText(e.option2Label);

        mainCanvas.SetActive(false);
        textCanvas.SetActive(true);
        buttonsCanvas.SetActive(true);
    }

    public void theAction(int action)
    {
        if (showingResult) return;

        int i = stats.currentAlley;
        if (i >= encounters.Length) return;

        AlleyEncounter e = encounters[i];

        if (action == 2)
        {
            stats.currentCash   += e.cashChange;
            stats.currentHealth += e.healthChange;
            stats.currentEnergy += e.energyChange;

            textBoxText.SetText(e.option2Result);

            if (e.option2SwitchesScene)
                pendingScene = e.sceneToLoad;
        }
        else
        {
            textBoxText.SetText(e.option1Result);
        }

        buttonsCanvas.SetActive(false);
        showingResult = true;
    }
}