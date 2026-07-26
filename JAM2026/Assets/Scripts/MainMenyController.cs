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
        if(stats.currentBarEnd ==1) barEnding = true; 
        if(stats.currentGoodEnd ==1) goodEnding = true;
    }
    private void Start()
    {
        endingText.SetText($"Bad End: {badEnding}\nGood End: {goodEnding}\nHomeles End: {homelessEndingg}\n Dead End: {deadEnding}\n Bar Ending: {barEnding}");   
    }
    public void playButton()
    {
        sceneManagey.SwitchScene("Office");
    }
    
}
