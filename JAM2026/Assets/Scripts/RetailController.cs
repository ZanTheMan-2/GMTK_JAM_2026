using UnityEngine;
using TMPro;

[System.Serializable]
public class QuizQuestion
{
    [TextArea(2, 4)] public string question;
    public string[] answers = new string[4];
    [Range(1, 4)] public int correct = 1;
}

public class RetailController : MonoBehaviour
{
    public SceneManagey sceneManagey;
    public Stats stats;

    public dialogController conStep1;
    public dialogController conStep2;
    public dialogController conStep3;

    public TextMeshProUGUI questionsText;
    public TextMeshProUGUI[] answerLabels = new TextMeshProUGUI[4];
    public GameObject quizz, canva, gui, getHiredStep1, getHiredStep2, getHiredStep3;
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;

    public QuizQuestion[] questions;
    [Tooltip("How many right answers needed to get the job")]
    public int passMark = 3;

    private int qPos = 0;
    private int score = 0;

    private void Start()
    {
        quizz.SetActive(false);
        if (resultPanel != null) resultPanel.SetActive(false);
        getHiredStep1.SetActive(false);
        getHiredStep2.SetActive(false);
        getHiredStep3.SetActive(false);
    }

    public void leaveButton()
    {
        sceneManagey.SwitchScene("Map");
    }

    public void getJobButton()
    {
        if (conStep1.IsRunning || conStep2.IsRunning || conStep3.IsRunning) return;
        if (quizz.activeSelf) return;
        if (resultPanel != null && resultPanel.activeSelf) return;

        dialogController active;

        if (stats.retailApply == 0)
        {
            getHiredStep1.SetActive(true);
            getHiredStep2.SetActive(false);
            getHiredStep3.SetActive(false);
            active = conStep1;
            stats.retailApply = 1;
        }
        else if (stats.retailApply == 2)
        {
            getHiredStep1.SetActive(false);
            getHiredStep2.SetActive(true);
            getHiredStep3.SetActive(false);
            active = conStep2;
        }
        else if (stats.retailApply == 3)
        {
            getHiredStep1.SetActive(false);
            getHiredStep2.SetActive(false);
            getHiredStep3.SetActive(true);
            active = conStep3;
        }
        else
        {
            return;   // nothing to do at this stage
        }

        canva.SetActive(true);
        active.Begin();
    }

    public void buyStuffButton()
    {

    }

    public void OnDialogFinished()
    {
        getHiredStep1.SetActive(false);
        getHiredStep2.SetActive(false);
        getHiredStep3.SetActive(false);

        if (stats.retailApply != 2) return;
        quiz();
    }

    public void quiz()
    {
        if (quizz.activeSelf) return;

        qPos = 0;
        score = 0;
        quizz.SetActive(true);
        gui.SetActive(false);
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        QuizQuestion q = questions[qPos];
        questionsText.SetText(q.question);

        for (int i = 0; i < answerLabels.Length; i++)
        {
            answerLabels[i].SetText(q.answers[i]);
        }
    }

    public void Answer1() { Answer(1); }
    public void Answer2() { Answer(2); }
    public void Answer3() { Answer(3); }
    public void Answer4() { Answer(4); }

    private void Answer(int choice)
    {
        if (choice == questions[qPos].correct) score++;

        qPos++;

        if (qPos >= questions.Length)
        {
            EndQuiz();
            return;
        }

        ShowQuestion();
    }

    private void EndQuiz()
    {
        quizz.SetActive(false);
        gui.SetActive(true);

        if (score >= passMark)
        {
            stats.retailApply = 3;
            resultText.SetText($"You got the job! ({score}/{questions.Length})");
        }
        else
        {
            stats.retailApply = 1;
            resultText.SetText($"Not even deserving this position ({score}/{questions.Length})");
        }

        resultPanel.SetActive(true);
    }
    public void unpaid()
    {
        sceneManagey.SwitchScene("Till");
    }
    public void CloseResult()
    {
        resultPanel.SetActive(false);
        sceneManagey.SwitchScene("Map");
    }
}