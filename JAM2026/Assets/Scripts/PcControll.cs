using UnityEngine;
using TMPro;
public class PcControll : MonoBehaviour
{
    private SceneManagey sceneManagey;
    private Stats stats;
    public GameObject retailButtons, officeButtons, applyButtons;
    public TextMeshProUGUI text, applyText;

    void Start()
    {
        retailButtons.SetActive(false);
        officeButtons.SetActive(false);
        applyButtons.SetActive(false);
        sceneManagey = GetComponent<SceneManagey>();
        stats = GetComponent<Stats>();
    }

    public void findJobButton()
    {
        retailButtons.SetActive(true);
        officeButtons.SetActive(true);
        
    }
    public void retailButton()
    {
        applyButtons.SetActive(true);
    }
    public void applyButton()
    {
        if(stats.retailApply == 1)
        {
            applyText.SetText("Failed");
        }
        else
        {
            applyText.SetText("Succsess");
            stats.retailApply = 1;
        }
    }
    public void officeButton()
    {
        text.SetText("Unavailable");
    }
    public void returnButton()
    {
        sceneManagey.SwitchScene("Home");
    }
}
