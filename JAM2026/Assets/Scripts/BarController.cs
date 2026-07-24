using UnityEngine;

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
    public SceneManagey sceneManagey;
    public Stats stats;

    public GameObject canva, gui;
    public BarStage[] stages;

    private BarStage current;

    private void Start()
    {
        HideAllStages();
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
        if (AnyDialogRunning()) return;
        if (stats.currentEnergy < 1) return;

        BarStage match = null;

        // only the stage whose pointsNeeded equals the current points
        foreach (BarStage s in stages)
        {
            if (s.pointsNeeded == stats.currentBarPoints)
            {
                match = s;
                break;
            }
        }

        if (match == null || match.dialog == null) return;

        stats.currentEnergy -= 1;
        current = match;

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

    public void AddPoints(int amount)
    {
        stats.currentBarPoints += amount;
    }

    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }
}