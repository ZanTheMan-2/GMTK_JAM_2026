using UnityEngine;

public class RetailController : MonoBehaviour
{
    private SceneManagey sceneManagey;
    public GameObject getHiredStep1;

    private void Start()
    {
        sceneManagey = GetComponent<SceneManagey>();
    }
    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }
    public void getJobButton()
    {
        getHiredStep1.SetActive(true);
    }
    public void buyStuffButton()
    {
        
    }
}
