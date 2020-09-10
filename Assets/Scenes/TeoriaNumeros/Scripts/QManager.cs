using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QManager : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private QGame quizGameUI;
    [SerializeField] private List<QData> quizDataList;
#pragma warning restore 649
    private List<Pregunta> questions;
    private Pregunta selectedQuetion = new Pregunta();
    private int gameScore;
    private QData dataScriptable;

    private StatusJuego gameStatus = StatusJuego.NEXT;

    public StatusJuego GameStatus { get { return gameStatus; } }

    public void StartGame(int categoryIndex)
    {
        questions = new List<Pregunta>();
        dataScriptable = quizDataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
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
        selectedQuetion = questions[val];
        quizGameUI.SetQuestion(selectedQuetion);

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

        if (gameStatus == StatusJuego.PLAYING)
        {
            if (questions.Count > 0)
            {
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                gameStatus = StatusJuego.NEXT;
            }
        }
        return correct;
    }
}

[System.Serializable]
public class Pregunta
{
    public string questionInfo;         //Texto
    public TipoPregunta questionType;   //tipo
    public Sprite questionImage;        //imagen
    public AudioClip audioClip;         //audio 
    public UnityEngine.Video.VideoClip videoClip;   //video
    public List<string> options;        //opciones
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