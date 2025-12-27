
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionPanel : MonoBehaviour
{
    [System.Serializable]
    public class YesNoQuestion
    {
        public string questionText;
        public bool correctAnswer; // true = Yes, false = No
    }

    public List<YesNoQuestion> allQuestions;      // List of all possible questions

    public Text[] questionTexts;                  // Assign 3 Text UI components
    public Toggle[] yesToggles;                   // 3 Yes toggles
    public Toggle[] noToggles;                    // 3 No toggles

    private YesNoQuestion[] selectedQuestions = new YesNoQuestion[3];

    void OnEnable()
    {
        GenerateRandomQuestions();
    }

    void GenerateRandomQuestions()
    {
        // Shuffle and pick 3 questions
        List<YesNoQuestion> shuffled = new List<YesNoQuestion>(allQuestions);
        for (int i = 0; i < shuffled.Count; i++)
        {
            int rnd = Random.Range(i, shuffled.Count);
            var temp = shuffled[i];
            shuffled[i] = shuffled[rnd];
            shuffled[rnd] = temp;
        }

        for (int i = 0; i < 3; i++)
        {
            selectedQuestions[i] = shuffled[i];
            questionTexts[i].text = selectedQuestions[i].questionText;

            // Reset toggles
            yesToggles[i].isOn = false;
            noToggles[i].isOn = false;
        }
    }

    public void SubmitAnswers()
    {
        int correct = 0;

        for (int i = 0; i < 3; i++)
        {
            bool playerAnswer = yesToggles[i].isOn;
            if (playerAnswer == selectedQuestions[i].correctAnswer)
            {
                correct++;
            }
        }

        if (correct >= 2)
        {
            Debug.Log("Passed!");
            GameManager.Instance.ResumeGame();
        }
        else
        {
            Debug.Log("Failed!");
            GameManager.Instance.GameOver();
        }
    }
}
