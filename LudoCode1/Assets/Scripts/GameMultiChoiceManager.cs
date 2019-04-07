using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameMultiChoiceManager : MonoBehaviour
{

    public Question_MultChoice[] questions;
    private static List<Question_MultChoice> unansweredQuestions;
    private Question_MultChoice currentQuestion;

    [SerializeField]
    private Text questionText, codeText, AText, BText, CText, playerAnswerAText, playerAnswerBText, playerAnswerCText;

    [SerializeField]
    private Animator animatorMultChoice;

    // 1s btw each question
    [SerializeField]
    private float timeBtwQuestions = 5f;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question_MultChoice>();
        }
       
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        codeText.text = currentQuestion.code;
        AText.text = currentQuestion.choiceA;
        BText.text = currentQuestion.choiceB;
        CText.text = currentQuestion.choiceC;

        if (currentQuestion.answer.Equals("A"))
        {
            playerAnswerAText.text = "CORRECT";
            playerAnswerBText.text = currentQuestion.choiceBHint;
            playerAnswerCText.text = currentQuestion.choiceCHint;
        }
        else if (currentQuestion.answer.Equals("B"))
        {
            playerAnswerAText.text = currentQuestion.choiceAHint;
            playerAnswerBText.text = "CORRECT";
            playerAnswerCText.text = currentQuestion.choiceCHint;
        }
        else if (currentQuestion.answer.Equals("C"))
        {
            playerAnswerAText.text = currentQuestion.choiceAHint;
            playerAnswerBText.text = currentQuestion.choiceBHint;
            playerAnswerCText.text = "CORRECT";
        }
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBtwQuestions);

        //Load the Scene with the index of our current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectAnswer(string choice)
    {

        animatorMultChoice.SetTrigger(choice);
        if (choice.Equals("A"))
        {
            if (currentQuestion.answer.Equals("A"))
            {
                Debug.Log("Correct A");
            }
            else
            {
                Debug.Log("Wrong! A");
            }
        }
        if (choice.Equals("B"))
        {
            if (currentQuestion.answer.Equals("B"))
            {
                Debug.Log("Correct B");
            }
            else
            {
                Debug.Log("Wrong! B");
            }
        }
        if (choice.Equals("C"))
        {
            if (currentQuestion.answer.Equals("C"))
            {
                Debug.Log("Correct C");
            }
            else
            {
                Debug.Log("Wrong! C");
            }
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
