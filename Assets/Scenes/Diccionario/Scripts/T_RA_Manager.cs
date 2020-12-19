using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_RA_Manager : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private T_RA_Game RAGame;
    [SerializeField] private List<T_RA_DataScriptable> RADataList;
#pragma warning restore 649
    private List<QuestionRA> questions;
    private QuestionRA selectedQuetion = new QuestionRA();
    private T_RA_DataScriptable dataScriptable;

    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }

    public void StartGame(int categoryIndex)
    {
        //set the questions data
        questions = new List<QuestionRA>();
        dataScriptable = RADataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
        //select the question
        SelectQuestion();
        gameStatus = GameStatus.PLAYING;
    }

    public void StartAudio(int categoryIndex)
    {
        //set the questions data
        questions = new List<QuestionRA>();
        dataScriptable = RADataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
        //select the question
        SelectQuestionAudio();
        gameStatus = GameStatus.PLAYING;
    }

    /// <summary>
    /// Method used to randomly select the question form questions data
    /// </summary>
    private void SelectQuestion()
    {
        //get the random number
        int val = UnityEngine.Random.Range(0, questions.Count);
        //set the selectedQuetion
        selectedQuetion = questions[val];
        //send the question to quizGameUI
        RAGame.SetQuestion(selectedQuetion);

        questions.RemoveAt(val);
    }

    private void SelectQuestionAudio()
    {
        //get the random number
        int val = UnityEngine.Random.Range(0, questions.Count);
        //set the selectedQuetion
        selectedQuetion = questions[val];
        //send the question to quizGameUI
        RAGame.SetAudio(selectedQuetion);

        questions.RemoveAt(val);
    }

    /// <summary>
    /// Method called to check the answer is correct or not
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        bool correct = false;
        if (gameStatus == GameStatus.PLAYING)
        {
            if (questions.Count > 0)
            {
                //call SelectQuestion method again after 1s
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                gameStatus = GameStatus.NEXT;
            }
        }
        return correct;
    }
}


//Datastructure for storeing the quetions data
[System.Serializable]
public class QuestionRA
{
    public string questionInfo;         //question text
    public QuestionTypeRA questionType;   //type
    public AudioClip audioClip;         //audio for audio type
    public List<string> options;        //options to select
}

[System.Serializable]
public enum QuestionTypeRA
{
    
    AUDIO
}

[SerializeField]
public enum GameStatusRA
{
    PLAYING,
    NEXT
}