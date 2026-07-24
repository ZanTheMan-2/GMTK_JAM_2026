using UnityEngine;
using TMPro;
public class MainMenyController : MonoBehaviour
{
    private SceneManagey sceneManagey;
    private Stats stats;
    public TextMeshProUGUI endingText;
    bool badEnding, goodEnding, homelessEnding, barEnding, deadEnding, homelessEndingg;
    private void Awake()
    {
        sceneManagey = GetComponent<SceneManagey>();
        stats = GetComponent<Stats>();
        if(stats.currentBadEnding == 1) badEnding = true;
        if(stats.currentHospitalEnding ==1) deadEnding = true;
        if(stats.currentHomelessEnding ==1) homelessEndingg = true;
    }
    private void Start()
    {
        endingText.SetText($"Bad Ending: {badEnding}\nGood Ending: false\nHomeles Ending: {homelessEndingg}\n Dead Ending: {deadEnding}\n Bar Ending: false");   
    }
    public void playButton()
    {
        sceneManagey.SwitchScene("Office");
    }
}
