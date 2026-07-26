using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
public class MainMenyController : MonoBehaviour
{
    private SceneManagey sceneManagey;
    private Stats stats;
    public TextMeshProUGUI endingText;
    bool badEnding, goodEnding, homelessEnding, barEnding, deadEnding, homelessEndingg;
    public GameObject gallary;
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
        gallary.SetActive(false);
        endingText.SetText($"Bad End: {badEnding}\nGood End: {goodEnding}\nHomeles End: {homelessEndingg}\n Dead End: {deadEnding}\n Bar Ending: {barEnding}");   
    }
    public void playButton()
    {
        sceneManagey.SwitchScene("Office");
    }
    public void closeButton()
    {
        gallary.SetActive(false);
    } 
    public void gallaryButton()
    {
        gallary.SetActive(true);
    }
    
}
