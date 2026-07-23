using UnityEngine;

public class RetailController : MonoBehaviour
{
    private SceneManagey sceneManagey;
    private dialogController con;
    private Stats stats;
    public GameObject canva,getHiredStep1,getHiredStep2;

    private void Start()
    {
        sceneManagey = GetComponent<SceneManagey>();
        stats = GetComponent<Stats>();
        con = GetComponent<dialogController>();
    }
    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }
    public void getJobButton()
    {
        canva.SetActive(true);
        con.enabled = false;
        getHiredStep1.SetActive(false);
        getHiredStep2.SetActive(false);
        if(stats.retailApply == 1)
        {
            getHiredStep1.SetActive(true);
        }else if (stats.retailApply == 2)
        {
            getHiredStep2.SetActive(true);
        }
    }
    public void buyStuffButton()
    {
        
    }
}
