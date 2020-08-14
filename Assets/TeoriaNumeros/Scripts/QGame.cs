using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QGame : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private QManager quizManager;               //ref to the QuizManager script
    [SerializeField] private Transicion transicion;
    //[SerializeField] private Text scoreText, timerText;
    //[SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject mainMenu, gamePanel;
    [SerializeField] private Color correctCol, wrongCol, normalCol; //color of buttons
    [SerializeField] private Image questionImg;                     //image component to show image
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;   //to show video
    [SerializeField] private AudioSource questionAudio;             //audio source for audio clip
    [SerializeField] private Text questionInfoText;                 //text to show question
    [SerializeField] private List<Button> options;                  //options button reference
    [SerializeField] private List<Button> uiButtons;
#pragma warning restore 649

    private float audioLength;          //store audio length
    private Pregunta question;          //store current question data
    private bool answered = false;      //bool to keep track if answered or not

    //public Text TimerText { get => timerText; }                     //getter
    //public Text ScoreText { get => scoreText; }                     //getter
    /*public GameObject GameOverPanel { get => gameOverPanel; }                     //getter*/

    private void Start()
    {   //add the listner to all the buttons
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

    }
    /// <summary>
    /// Method which populate the question on the screen
    /// </summary>
    /// <param name="question"></param>
    public void SetQuestion(Pregunta question)
    {
        //set the question
        this.question = question;
        //check for questionType
        switch (question.questionType)
        {
            case TipoPregunta.TEXT:
                questionImg.transform.parent.gameObject.SetActive(false);   
                break;
            case TipoPregunta.IMAGE:
                questionImg.transform.parent.gameObject.SetActive(true);    
                questionVideo.transform.gameObject.SetActive(false);        
                questionImg.transform.gameObject.SetActive(true);           
                questionAudio.transform.gameObject.SetActive(false);        

                questionImg.sprite = question.questionImage;                
                break;
            case TipoPregunta.AUDIO:
                questionVideo.transform.parent.gameObject.SetActive(true);  
                questionVideo.transform.gameObject.SetActive(false);       
                questionImg.transform.gameObject.SetActive(true);          
                questionAudio.transform.gameObject.SetActive(true);

                questionImg.sprite = question.questionImage;

                audioLength = question.audioClip.length;
                StartCoroutine(PlayAudio());                               
                break;
            case TipoPregunta.VIDEO:
                questionVideo.transform.parent.gameObject.SetActive(true);  
                questionVideo.transform.gameObject.SetActive(true);         
                questionImg.transform.gameObject.SetActive(false);          
                questionAudio.transform.gameObject.SetActive(false);        

                questionVideo.clip = question.videoClip;                    //poner video clip
                questionVideo.Play();                                       //play video
                break;
        }

        questionInfoText.text = question.questionInfo;                      //set the question text

        //suffle the list of options
        /*List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.options);

        //assign options to respective option buttons
        for (int i = 0; i < options.Count; i++)
        {
            //set the child text
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    //set the name of button
            options[i].image.color = normalCol; //set color of button to normal
        }*/

        answered = false;                       

    }

    /*public void ReduceLife(int remainingLife)
    {
        lifeImageList[remainingLife].color = Color.red;
    }*/

    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (question.questionType == TipoPregunta.AUDIO)
        {
            //PlayOneShot
            questionAudio.PlayOneShot(question.audioClip);
            //wait for few seconds
            yield return new WaitForSeconds(audioLength + 0.5f);
            //play again
            //StartCoroutine(PlayAudio());
        }
        else //if questionType is not audio
        {
            //stop the Coroutine
            StopCoroutine(PlayAudio());
            //return null
            yield return null;
        }
    }

    /// <summary>
    /// Method assigned to the buttons
    /// </summary>
    /// <param name="btn">ref to the button object</param>
    void OnClick(Button btn)
    {
        if (quizManager.GameStatus == StatusJuego.PLAYING)
        {
            audioLength = question.audioClip.length;
            StartCoroutine(PlayAudio());
            //if answered is false
            /*if (!answered)
            {
                //set answered true
                answered = true;
                //get the bool value
                bool val = quizManager.Answer(btn.name);

                

                //if its true
                if (val)
                {
                    //set color to correct
                    btn.image.color = correctCol;


                }
                else
                {
                    //else set it to wrong color
                    btn.image.color = wrongCol;
                }
            }*/
        }

        switch (btn.name)
        {
            case "uno":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "dos":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "tres":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "cuatro":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "cinco":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "seis":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "siete":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "ocho":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "nueve":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "diez":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "once":
                quizManager.StartGame(10);
                transicion.ButtonMenu();
                break;
            case "doce":
                quizManager.StartGame(11);
                transicion.ButtonMenu();
                break;
            case "trece":
                quizManager.StartGame(12);
                transicion.ButtonMenu();
                break;
            case "catorce":
                quizManager.StartGame(13);
                transicion.ButtonMenu();
                break;
            case "quince":
                quizManager.StartGame(14);
                transicion.ButtonMenu();
                break;
            case "dieciseis":
                quizManager.StartGame(15);
                transicion.ButtonMenu();
                break;
            case "diecisiete":
                quizManager.StartGame(16);
                transicion.ButtonMenu();
                break;
            case "dieciocho":
                quizManager.StartGame(17);
                transicion.ButtonMenu();
                break;
            case "diecinueve":
                quizManager.StartGame(18);
                transicion.ButtonMenu();
                break;
            case "veinte":
                quizManager.StartGame(19);
                transicion.ButtonMenu();
                break;
        }
    }

    public void RestryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
