using UnityEngine;
using TMPro;
[System.Serializable]
public class BarStage
{
    public int pointsNeeded;
    public int pointsAwarded = 1;  
    public GameObject Dialog;
    public dialogController dialog;

}

public class BarController : MonoBehaviour
{
    private int price,  health,  energy,  effect;
    public TextMeshProUGUI priceText;

    public SceneManagey sceneManagey;
    public Stats stats;

    public GameObject canva, gui, itemBuys, buttons;
    public BarStage[] stages;

    private BarStage current;

    private void Start()
    {
        HideAllStages();
        itemBuys.SetActive(false);
    }
   

    private void HideAllStages()
    {
        foreach (BarStage s in stages)
        {
            if (s.Dialog != null) s.Dialog.SetActive(false);
        }
    }

    private bool AnyDialogRunning()
    {
        foreach (BarStage s in stages)
        {
            if (s.dialog != null && s.dialog.IsRunning) return true;
        }
        return false;
    }

    public void talkButton()
    {
        Debug.Log("here");
        if (AnyDialogRunning()) return;
        if (stats.currentEnergy < 1) return;

        BarStage match = null;
        Debug.Log("here2");

        // only the stage whose pointsNeeded equals the current points
        foreach (BarStage s in stages)
        {
                    Debug.Log("here3");

            if (s.pointsNeeded == stats.currentBarPoints)
            {
                        Debug.Log("here4");

                match = s;
                break;
            }
        }

        if (match == null || match.dialog == null) return;

        stats.currentEnergy -= 1;
        current = match;

            Debug.Log("here5");

        HideAllStages();
        match.Dialog.SetActive(true);
        canva.SetActive(true);
        match.dialog.Begin();
    }

    // wire to every stage dialogue's On Finished ()
    public void OnDialogFinished()
    {
        HideAllStages();

        if (current != null)
        {
            stats.currentBarPoints += current.pointsAwarded;
            current = null;
        }
    }
        //Buttons

    public void AddPoints(int amount)
    {
        stats.currentBarPoints += amount;
    }
    public void displayItemButton()
    {
        buttons.SetActive(false);
       itemBuys.SetActive(true) ;
    }
    public void closeItemsButton()
    {
        buttons.SetActive(true);
        itemBuys.SetActive(false);
    }
    private void select(int Price, int Health, int Energy, int Effect)
    {
        price = Price; health = Health; energy = Energy; effect =Effect;
        priceText.SetText(Price.ToString());
    }

    public void waterButton() {select(10,1,0,0);}
    public void beerButton() {select(15,-2,-2,0);}
    public void deathDrinkButton() {select(400,-10,2,0);}
    public void theAfterLifeButton() {select(400,1,1,2);}

    public void buyButton()
    {
        if(stats.currentCash >= price)
        {
            stats.currentCash -= price;
            stats.currentHealth += health;
            stats.currentEnergy +=energy;

            if(effect == 2){
                stats.currentBarEnd = 1;
                 barEnd();
                 }
        }
        else
        {
            priceText.SetText("Too Poor");
        }
    }
    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }

    private void barEnd()
    {
        sceneManagey.SwitchScene("BarEnd");
    }
}