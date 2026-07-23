using UnityEngine;
using TMPro;
public class MainMenyController : MonoBehaviour
{
    private SceneManagey sceneManagey;
    private Stats stats;
    public TextMeshProUGUI endingText;
    bool badEnding, goodEnding, homelessEnding, barEnding;
    private void Awake()
    {
        sceneManagey = GetComponent<SceneManagey>();
        stats = GetComponent<Stats>();
        if(stats.currentBadEnding == 1) badEnding = true;
        
    }
    private void Start()
    {
        endingText.SetText($"Bad Ending: {badEnding}\nGood Ending: false\nHomeles Ending: false\n Bar Ending: false");   
    }
    public void playButton()
    {
        sceneManagey.SwitchScene("Office");
    }
}
