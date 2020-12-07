using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizGameUI : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Game gameE;
    [SerializeField] private QuizManager quizManager;    
    [SerializeField] private Text scoreText, timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel, mainMenu, gamePanel;
    [SerializeField] private Color correctCol, wrongCol, normalCol; 
    [SerializeField] private Image questionImg;                    
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;   
    [SerializeField] private AudioSource questionAudio;           
    [SerializeField] private Text questionInfoText;                
    [SerializeField] private List<Button> options;                  
    [SerializeField] private List<Button> uiButtons;
    
#pragma warning restore 649

    private float audioLength;          
    private Question question;          
    private bool answered = false;
   

    public Text TimerText { get => timerText; }                    
    public Text ScoreText { get => scoreText; }                     
    public GameObject GameOverPanel { get => gameOverPanel; }              

    private void Start()
    {
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
    public void SetQuestion(Question question)
    {
        this.question = question;
        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImg.transform.parent.gameObject.SetActive(false);   
                break;
            case QuestionType.IMAGE:
                questionImg.transform.parent.gameObject.SetActive(true);    
                questionVideo.transform.gameObject.SetActive(false);        
                questionImg.transform.gameObject.SetActive(true);           
                questionAudio.transform.gameObject.SetActive(false);        

                questionImg.sprite = question.questionImage;                
                break;
            case QuestionType.AUDIO:
                questionVideo.transform.parent.gameObject.SetActive(true);  
                questionVideo.transform.gameObject.SetActive(false);       
                questionImg.transform.gameObject.SetActive(false);          
                questionAudio.transform.gameObject.SetActive(true);         
                
                audioLength = question.audioClip.length;                    
                StartCoroutine(PlayAudio());                               
                break;
            case QuestionType.VIDEO:
                questionVideo.transform.parent.gameObject.SetActive(true);  
                questionVideo.transform.gameObject.SetActive(true);         
                questionImg.transform.gameObject.SetActive(false);          
                questionAudio.transform.gameObject.SetActive(false);        

                questionVideo.clip = question.videoClip;                    
                questionVideo.Play();                                       
                break;
        }

        questionInfoText.text = question.questionInfo;                    
        
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.options);
        
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    
            options[i].image.color = normalCol; 
        }

        answered = false;                       

    }

    public void ReduceLife(int remainingLife)
    {
        lifeImageList[remainingLife].color = Color.red;
    }

    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (question.questionType == QuestionType.AUDIO)
        {
            ///////////lol/77777//////////
            questionAudio.PlayOneShot(question.audioClip);
            yield return new WaitForSeconds(audioLength + 2.5f);
            StartCoroutine(PlayAudio());
            
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
    public void OnClick(Button btn)
    {
        if (quizManager.GameStatus == GameStatus.PLAYING)
        {
            if (!answered)
            {
                answered = true;
                bool val = quizManager.Answer(btn.name);

                if (val)
                {
                    btn.image.color = correctCol;
                }
                else
                {
                    btn.image.color = wrongCol;
                }
            }
        }
        switch (btn.name)
        {
            case "QImagenes":
                if (Game.tecla==1)
                {
                    quizManager.StartGame(0);

                }
                if (Game.tecla==2)
                {
                    quizManager.StartGame(2);
                }
                if (Game.tecla == 3)
                {
                    quizManager.StartGame(4);
                }
                if (Game.tecla == 4)
                {
                    quizManager.StartGame(6);
                }
                if (Game.tecla == 5)
                {
                    quizManager.StartGame(8);
                }
                if (Game.tecla == 6)
                {
                    quizManager.StartGame(10);
                }
                if (Game.tecla == 7)
                {
                    quizManager.StartGame(12);
                }
                if (Game.tecla == 8)
                {
                    quizManager.StartGame(14);
                }
                if (Game.tecla == 9)
                {
                    quizManager.StartGame(16);
                }
                mainMenu.SetActive(false);
                gamePanel.SetActive(true);
                break;
            case "QSonidos":
                if (Game.tecla == 1)
                {
                    quizManager.StartGame(1);

                }
                if (Game.tecla == 2)
                {
                    quizManager.StartGame(3);
                }
                if (Game.tecla == 3)
                {
                    quizManager.StartGame(5);
                }
                if (Game.tecla == 4)
                {
                    quizManager.StartGame(7);
                }
                if (Game.tecla == 5)
                {
                    quizManager.StartGame(9);
                }
                if (Game.tecla == 6)
                {
                    quizManager.StartGame(11);
                }
                if (Game.tecla == 7)
                {
                    quizManager.StartGame(13);
                }
                if (Game.tecla == 8)
                {
                    quizManager.StartGame(15);
                }
                if (Game.tecla == 9)
                {
                    quizManager.StartGame(17);
                }
                mainMenu.SetActive(false);
                gamePanel.SetActive(true);
                break;

            case "Palabras":
                if (Game.tecla == 1)
                {
                    Escena("Ejercicios_Menu");

                }
                if (Game.tecla == 2)
                {
                    Escena("EjercicioPalabrasNumeros");
                }
                if (Game.tecla == 3)
                {
                    Escena("EjercicioPartesCuerpo");
                }
                if (Game.tecla == 4)
                {
                    Escena("EjercicioPartesCasa");
                }
                if (Game.tecla == 5)
                {
                    Escena("EjercicioPartesAnimales");
                }
                if (Game.tecla == 6)
                {
                    Escena("EjercicioPartesArbol");
                }
                if (Game.tecla == 7)
                {
                    Escena("EjerciciosAnimales");
                }
                if (Game.tecla == 8)
                {
                    Escena("EjerciciosFrutas");
                }
                if (Game.tecla == 9)
                {
                    Escena("EjerciciosCosas");
                }
                break;
        }
    }

    public void Escena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

}
