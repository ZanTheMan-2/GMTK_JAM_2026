using UnityEngine;
using TMPro;
using Unity.VectorGraphics;

[System.Serializable]
public class BarStage
{
    public int pointsNeeded;            // bar points required to reach this stage
    public GameObject Dialog;     
    public dialogController dialog;
}

public class BarController : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public Stats stats;

    public GameObject canva, gui;
    public BarStage[] stages;


    private void Start()
    {
        if(stats.currentBarPoints == 0) canva.SetActive(true);
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

        BarStage best = null;

        // highest stage the player currently qualifies for
        foreach (BarStage s in stages)
        {
            if (stats.currentBarPoints >= s.pointsNeeded)
            {
                if (best == null || s.pointsNeeded > best.pointsNeeded) best = s;
            }
        }

        HideAllStages();
        best.Dialog.SetActive(true);
        canva.SetActive(true);
        best.dialog.Begin();
    }

    
    public void OnDialogFinished()
    {
        HideAllStages();
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