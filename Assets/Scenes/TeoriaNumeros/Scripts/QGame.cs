using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QGame : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private QManager quizManager;              
    [SerializeField] private Transicion transicion;
    [SerializeField] private GameObject mainMenu, gamePanel;
    [SerializeField] private Image questionImg;                    
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;   
    [SerializeField] private AudioSource questionAudio;             
    [SerializeField] private Text questionInfoText;                 
    [SerializeField] private List<Button> options;                  
    [SerializeField] private List<Button> uiButtons;
#pragma warning restore 649

    private float audioLength;          
    private Pregunta question;          
    private bool answered = false;      
    private Animator animador;

    private void Start()
    {   //add the listner to all the buttons
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => Animacion(localBtn));
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => Animacion(localBtn));
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
                //T. numeros y T. Cuerpo
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

        questionInfoText.text = question.questionInfo;                      

        List<string> ansOptions = SList.ShuffleListItems<string>(question.options);
        
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    
        }

        answered = false;                       

    }
    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (question.questionType == TipoPregunta.AUDIO)
        {
            questionAudio.PlayOneShot(question.audioClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
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
    void OnClick(Button btn)
    {
        if (quizManager.GameStatus == StatusJuego.PLAYING)
        {
            audioLength = question.audioClip.length;
           // StartCoroutine(PlayAudio());
        }

        switch (btn.name)
        {
            case "Option1":
                audioLength = question.audioClip.length;
                StartCoroutine(PlayAudio());
                break;
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
            case "cabeza":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "cara":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "frente":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "ojo":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "nariz":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "oreja":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "hombro":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "brazo":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "estomago":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "boca":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "cuello":
                quizManager.StartGame(10);
                transicion.ButtonMenu();
                break;
            case "pie":
                quizManager.StartGame(11);
                transicion.ButtonMenu();
                break;
            case "pierna":
                quizManager.StartGame(12);
                transicion.ButtonMenu();
                break;
            case "rama":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "Hoja":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "Raiz":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "Tronco":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "Copa":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "techo":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "puerta":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "cimiento":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "pared":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "interior":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "cabezaA":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "caraA":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "frenteA":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "ojoA":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "narizA":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "bocaA":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "cuelloA":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "manoA":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "pata":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "panza":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "piernaA":
                quizManager.StartGame(10);
                transicion.ButtonMenu();
                break;
            case "cola":
                quizManager.StartGame(11);
                transicion.ButtonMenu();
                break;
            case "ala":
                quizManager.StartGame(12);
                transicion.ButtonMenu();
                break;
            case "pico":
                quizManager.StartGame(13);
                transicion.ButtonMenu();
                break;
            case "gato":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "perro":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "culebra":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "coralillo":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "tortuga":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "pez":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "cangrejo":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "borrego":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "vaca":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "buho":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "toro":
                quizManager.StartGame(10);
                transicion.ButtonMenu();
                break;
            case "raton":
                quizManager.StartGame(11);
                transicion.ButtonMenu();
                break;
            case "mapache":
                quizManager.StartGame(12);
                transicion.ButtonMenu();
                break;
            case "araña":
                quizManager.StartGame(13);
                transicion.ButtonMenu();
                break;
            case "lagartija":
                quizManager.StartGame(14);
                transicion.ButtonMenu();
                break;
            case "ardilla":
                quizManager.StartGame(15);
                transicion.ButtonMenu();
                break;
            case "venado":
                quizManager.StartGame(16);
                transicion.ButtonMenu();
                break;
            case "comal":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "cuchillo":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "lumbre":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "escoba":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "espejo":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "metate":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "hacha":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "hueso":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "silla":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "escalera":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "platano":
                quizManager.StartGame(0);
                transicion.ButtonMenu();
                break;
            case "sandia":
                quizManager.StartGame(1);
                transicion.ButtonMenu();
                break;
            case "piña":
                quizManager.StartGame(2);
                transicion.ButtonMenu();
                break;
            case "naranja":
                quizManager.StartGame(3);
                transicion.ButtonMenu();
                break;
            case "limon":
                quizManager.StartGame(4);
                transicion.ButtonMenu();
                break;
            case "guayaba":
                quizManager.StartGame(5);
                transicion.ButtonMenu();
                break;
            case "nispero":
                quizManager.StartGame(6);
                transicion.ButtonMenu();
                break;
            case "aguacate":
                quizManager.StartGame(7);
                transicion.ButtonMenu();
                break;
            case "mango":
                quizManager.StartGame(8);
                transicion.ButtonMenu();
                break;
            case "tuna":
                quizManager.StartGame(9);
                transicion.ButtonMenu();
                break;
            case "pitahaya":
                quizManager.StartGame(10);
                transicion.ButtonMenu();
                break;
            case "granada":
                quizManager.StartGame(11);
                transicion.ButtonMenu();
                break;
        }
        StartCoroutine(PlayAudio());
    }
    public void RestryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Animacion(Button localBtn)
    {
        animador = localBtn.animator; ;
        animador.Play("AnimBoton", 0, 0.25f);
    }
}
