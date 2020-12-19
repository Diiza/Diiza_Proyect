using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class T_RA_Game : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private T_RA_Manager RAManager;                    
    [SerializeField] private AudioSource questionAudio;           
    [SerializeField] private Text questionInfoText;                
    [SerializeField] private List<Button> options;
    [SerializeField] private GameObject Traductor, Sound;

#pragma warning restore 649

    private float audioLength;          
    private QuestionRA question;          
    private bool answered = false;
      
         

    private void Start()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => IndentificateSound());
        }

    }
    private void Update()
    {
        Debug.Log("CAMBIO " + DefaultTrackableEventHandler.TargetStatus);
        if (DefaultTrackableEventHandler.TargetStatus == false)
        {
            Traductor.SetActive(false);
            Sound.SetActive(false);
        }
        else
        {
            Traductor.SetActive(true);
            Sound.SetActive(true);
            Indentificate();

        }
    }
    /// <summary>
    /// Method which populate the question on the screen
    /// </summary>
    /// <param name="question"></param>
    public void SetQuestion(QuestionRA question)
    {
        this.question = question;
        questionInfoText.text = question.questionInfo;                    
        
        List<string> ansOptions = T_RA_List.ShuffleListItems<string>(question.options);
        
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    
        }

        answered = false;                       

    }

    /// <summary>
    /// Method which populate the question on the screen
    /// </summary>
    /// <param name="question"></param>
    public void SetAudio(QuestionRA question)
    {
        switch (question.questionType)
        {
            case QuestionTypeRA.AUDIO:

                questionAudio.transform.gameObject.SetActive(true);

                audioLength = question.audioClip.length;
                StartCoroutine(PlayAudio());

                break;
        }

    }






    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (question.questionType == QuestionTypeRA.AUDIO )
        {
            questionAudio.PlayOneShot(question.audioClip);
        }
        else 
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    /// <summary>
    /// Method assigned to the buttons
    /// </summary>
    /// <param name="btn">ref to the button object</param>
    public void Indentificate()
    {
        switch (DefaultTrackableEventHandler.TargetName)
        {
            case "AguaM":
                RAManager.StartGame(0);
                break;
            case "AireM":
                RAManager.StartGame(1);
                break;
            case "Burro":
                RAManager.StartGame(0);
                break;
            case "cuadro":
                RAManager.StartGame(1);
                break;
            case "Calle":
                RAManager.StartGame(0);
                break;
            case "cocodrilo":
                RAManager.StartGame(1);
                break;
            case "carne":
                RAManager.StartGame(2);
                break;
            case "Casa":
                RAManager.StartGame(3);
                break;
            case "chile":
                RAManager.StartGame(4);
                break;
            case "conejo":
                RAManager.StartGame(5);
                break;
            case "elote":
                RAManager.StartGame(0);
                break;
            case "espina":
                RAManager.StartGame(1);
                break;
            case "flor":
                RAManager.StartGame(0);
                break;
            case "foco":
                RAManager.StartGame(1);
                break;
            case "gallina":
                RAManager.StartGame(0);
                break;
            case "gato":
                RAManager.StartGame(1);
                break;
            case "guajolote":
                RAManager.StartGame(2);
                break;
            case "guayaba":
                RAManager.StartGame(3);
                break;
            case "hongo":
                RAManager.StartGame(0);
                break;
            case "hormiga":
                RAManager.StartGame(1);
                break;
            case "jirafa":
                RAManager.StartGame(0);
                break;
            case "jarra":
                RAManager.StartGame(1);
                break;
            case "lentes":
                RAManager.StartGame(0);
                break;
            case "leon":
                RAManager.StartGame(1);
                break;
            case "mariposa":
                RAManager.StartGame(0);
                break;
            case "puerco":
                RAManager.StartGame(1);
                break;
            case "nino":
                RAManager.StartGame(0);
                break;
            case "noche":
                RAManager.StartGame(1);
                break;
            case "olla":
                RAManager.StartGame(0);
                break;
            case "pato":
                RAManager.StartGame(0);
                break;
            case "perro":
                RAManager.StartGame(1);
                break;
            case "piedra":
                RAManager.StartGame(2);
                break;
            case "pollito":
                RAManager.StartGame(3);
                break;
            case "sol":
                RAManager.StartGame(0);
                break;
            case "sueter":
                RAManager.StartGame(1);
                break;
            case "television":
                RAManager.StartGame(0);
                break;
            case "trebol":
                RAManager.StartGame(1);
                break;
            case "tumba":
                RAManager.StartGame(2);
                break;
            case "tortuga":
                RAManager.StartGame(3);
                break;
            case "ventana":
                RAManager.StartGame(0);
                break;
            case "zorrillo":
                RAManager.StartGame(0);
                break;
        }

    }
    public void IndentificateSound()
    {
        switch (DefaultTrackableEventHandler.TargetName)
        {
            case "AguaM":
                RAManager.StartAudio(0);
                break;
            case "AireM":
                RAManager.StartAudio(1);
                break;
            case "Burro":
                RAManager.StartAudio(0);
                break;
            case "cuadro":
                RAManager.StartAudio(1);
                break;
            case "Calle":
                RAManager.StartAudio(0);
                break;
            case "cocodrilo":
                RAManager.StartAudio(1);
                break;
            case "carne":
                RAManager.StartAudio(2);
                break;
            case "Casa":
                RAManager.StartAudio(3);
                break;
            case "chile":
                RAManager.StartAudio(4);
                break;
            case "conejo":
                RAManager.StartAudio(5);
                break;
            case "elote":
                RAManager.StartAudio(0);
                break;
            case "espina":
                RAManager.StartAudio(1);
                break;
            case "flor":
                RAManager.StartAudio(0);
                break;
            case "foco":
                RAManager.StartAudio(1);
                break;
            case "gallina":
                RAManager.StartAudio(0);
                break;
            case "gato":
                RAManager.StartAudio(1);
                break;
            case "guajolote":
                RAManager.StartAudio(2);
                break;
            case "guayaba":
                RAManager.StartAudio(3);
                break;
            case "hongo":
                RAManager.StartAudio(0);
                break;
            case "hormiga":
                RAManager.StartAudio(1);
                break;
            case "jirafa":
                RAManager.StartAudio(0);
                break;
            case "jarra":
                RAManager.StartAudio(1);
                break;
            case "lentes":
                RAManager.StartAudio(0);
                break;
            case "leon":
                RAManager.StartAudio(1);
                break;
            case "mariposa":
                RAManager.StartAudio(0);
                break;
            case "puerco":
                RAManager.StartAudio(1);
                break;
            case "nino":
                RAManager.StartAudio(0);
                break;
            case "noche":
                RAManager.StartAudio(1);
                break;
            case "olla":
                RAManager.StartAudio(0);
                break;
            case "pato":
                RAManager.StartAudio(0);
                break;
            case "perro":
                RAManager.StartAudio(1);
                break;
            case "piedra":
                RAManager.StartAudio(2);
                break;
            case "pollito":
                RAManager.StartAudio(3);
                break;
            case "sol":
                RAManager.StartAudio(0);
                break;
            case "sueter":
                RAManager.StartAudio(1);
                break;
            case "television":
                RAManager.StartAudio(0);
                break;
            case "trebol":
                RAManager.StartAudio(1);
                break;
            case "tumba":
                RAManager.StartAudio(2);
                break;
            case "tortuga":
                RAManager.StartAudio(3);
                break;
            case "ventana":
                RAManager.StartAudio(0);
                break;
            case "zorrillo":
                RAManager.StartAudio(0);
                break;
        }

    }

}
