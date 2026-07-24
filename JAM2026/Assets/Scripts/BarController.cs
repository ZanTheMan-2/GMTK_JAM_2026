using UnityEngine;
using TMPro;

[System.Serializable]
public class BarStage
{
    public int pointsNeeded;        // bar points required to reach this stage
    public int pointsAwarded = 1;   // points gained once this one is finished
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

        BarStage best = null;

        // highest stage the player currently qualifies for
        foreach (BarStage s in stages)
        {
            if (stats.currentBarPoints >= s.pointsNeeded)
            {
                if (best == null || s.pointsNeeded > best.pointsNeeded) best = s;
            }
        }

        if (best == null || best.dialog == null) return;

        stats.currentEnergy -= 1;
        current = best;

        HideAllStages();
        best.Dialog.SetActive(true);
        canva.SetActive(true);
        best.dialog.Begin();
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