using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QManager : MonoBehaviour
{
#pragma warning disable 649
    //ref to the QuizGameUI script
    [SerializeField] private QGame quizGameUI;
    //ref to the scriptableobject file
    [SerializeField] private List<QData> quizDataList;
    //[SerializeField] private float timeInSeconds;
#pragma warning restore 649
    //questions data
    private List<Pregunta> questions;
    //current question data
    private Pregunta selectedQuetion = new Pregunta();
    private int gameScore;
    //private int lifesRemaining;
    //private float currentTime;
    private QData dataScriptable;

    private StatusJuego gameStatus = StatusJuego.NEXT;

    public StatusJuego GameStatus { get { return gameStatus; } }

    public void StartGame(int categoryIndex)
    {
        gameScore = 0;
        //lifesRemaining = 3;
        //currentTime = timeInSeconds;
        //-set the questions data
        questions = new List<Pregunta>();
        dataScriptable = quizDataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
        //select the question
        SelectQuestion();
        gameStatus = StatusJuego.PLAYING;
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
        quizGameUI.SetQuestion(selectedQuetion);

        questions.RemoveAt(val);
    }

    private void Update()
    {
        /*if (gameStatus == GameStatus.PLAYING)
        {
            currentTime -= Time.deltaTime;
            SetTime(currentTime);
        }*/
    }

    /*void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //set the time value
        quizGameUI.TimerText.text = time.ToString("mm':'ss");   //convert time to Time format

        if (currentTime <= 0)
        {
            //Game Over
            gameStatus = GameStatus.NEXT;
            quizGameUI.GameOverPanel.SetActive(true);
        }
    }*/

    /// <summary>
    /// Method called to check the answer is correct or not
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        //set default to false
        bool correct = false;
        //if selected answer is similar to the correctAns
        /*if (selectedQuetion.correctAns == selectedOption)
        {
            //Yes, Ans is correct
            correct = true;
            gameScore += 50;
            quizGameUI.ScoreText.text = "Puntos:" + gameScore;
        }
        else
        {
            //No, Ans is wrong
            //Reduce Life
            lifesRemaining--;
            quizGameUI.ReduceLife(lifesRemaining);

            if (lifesRemaining == 0)
            {
                gameStatus = GameStatus.NEXT;
                quizGameUI.GameOverPanel.SetActive(true);
            }
        }*/

        if (gameStatus == StatusJuego.PLAYING)
        {
            if (questions.Count > 0)
            {
                //call SelectQuestion method again after 1s
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                gameStatus = StatusJuego.NEXT;
                //quizGameUI.GameOverPanel.SetActive(true);
            }
        }
        //-return the value of correct bool
        return correct;
    }
}

//Datastructure for storeing the quetions data
[System.Serializable]
public class Pregunta
{
    public string questionInfo;         //question text
    public TipoPregunta questionType;   //type
    public Sprite questionImage;        //image for Image Type
    public AudioClip audioClip;         //audio for audio type
    public UnityEngine.Video.VideoClip videoClip;   //video for video type
    public List<string> options;        //options to select
    public string correctAns;           //correct option
}

[System.Serializable]
public enum TipoPregunta
{
    TEXT,
    IMAGE,
    AUDIO,
    VIDEO
}

[SerializeField]
public enum StatusJuego
{
    PLAYING,
    NEXT
}