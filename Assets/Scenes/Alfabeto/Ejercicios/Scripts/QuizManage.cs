
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManage : MonoBehaviour
{
    public static QuizManage instance;
    [SerializeField]
    private QuizDataScriptableObjects questionData;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private WordDatas[] answerWordArray;
    [SerializeField]
    private WordDatas[] optionsWordArray;
    [SerializeField]
    private Button audioButton;
    [SerializeField]
    private Button nextQuestion;
    [SerializeField]
    private GameObject results;
    private List<Results> info;
    [SerializeField]
    private List<Text> listResults;
    [SerializeField]
    private Text header;
    [SerializeField]
    private GameObject finalMessage;

    private Sprite[] arraySprite;
    private QuestionDatas answerWord;
    private List<int> selectedWordIndex;
    private int currentQuestionIndex = 0;
    private int currentAnswerIndex = 0;
    private int correctItem;
    private bool correctAnswer;
    private int totalItem;
    private List<Button> listButtonOptions;
    private int totalOptions;
    private int indexKey;
    private AudioClip audioclip;
    private bool answerdQuestion;
    private int score = 0;
    private List<int> indexGaps;
    private List<QuestionDatas> auxListData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

        selectedWordIndex = new List<int>();
        listButtonOptions = new List<Button>();
        arraySprite = new Sprite[12];
        info = new List<Results>();
        header.GetComponent<Text>();
        // StartSettings();
        auxListData = new List<QuestionDatas>();
        //  auxListData = questionData.questions;
        auxListData = BlendList.BlendListItems(questionData.questions);
        SetQuestion();
        GetButtonsOptions();
    }

    private void StartSettings()
    {
        answerdQuestion = false;
        correctItem = 0;
        totalItem = 0;
        correctAnswer = false;
        nextQuestion.gameObject.SetActive(false);
        selectedWordIndex.Clear();
        indexKey = 0;
        totalOptions = questionData.options.Count;
        answerWord = auxListData[currentQuestionIndex];
        questionImage.sprite = auxListData[currentQuestionIndex].questionImage;
        header.text = auxListData[currentQuestionIndex].nameImage;
    }

    private void SetQuestion()
    {
        StartSettings();
        SetAudio();
        ResetQuestion();

        indexGaps = new List<int>();
        for (int i = 0; i < answerWord.answer.Count; i++)
        {
            Image imagen = answerWordArray[i].GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
            imagen.sprite = answerWord.answer[i];

            if (imagen.sprite == null)
            {
                indexGaps.Add(i);
            }
        }

        for (int i = 0; i < totalOptions; i++)
        {
            Image imagen = optionsWordArray[i].GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
            imagen.sprite = questionData.options[i].options;
        }
    }

    public void SelectedOption(Button btn)
    {

        if (answerdQuestion == false)
        {
            for (int i = 0; i < listButtonOptions.Count; i++)
            {
                if (btn.name == listButtonOptions[i].name)
                {
                    Image imagen = answerWordArray[indexGaps[totalItem]].GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
                    imagen.sprite = questionData.options[i].options;

                    if (i == auxListData[currentQuestionIndex].key[indexKey])
                    {
                        correctItem++;
                        Debug.Log("Item is Correct");
                        if (correctItem == auxListData[currentQuestionIndex].key.Count)
                        {
                            correctAnswer = true;
                            score += 50;
                            Debug.Log("Respuesta Correcta");
                        }
                    }


                    if (indexKey < auxListData[currentAnswerIndex].key.Count)
                    {
                        indexKey++;
                    }
                    if (indexKey == auxListData[currentAnswerIndex].key.Count)
                    {
                        answerdQuestion = true;
                        nextQuestion.gameObject.SetActive(true);
                    }
                    totalItem++;
                }
            }
        }
    }

    public void ResetQuestion()
    {

        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
        }

        for (int i = answerWord.answer.Count; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < totalOptions; i++)
        {
            optionsWordArray[i].gameObject.SetActive(true);
        }

        for (int i = totalOptions; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        SetQuestion();
    }

    private void GetButtonsOptions()
    {

        Debug.Log(questionData.options.Count);
        for (int i = 0; i < totalOptions; i++)
        {
            // Debug.Log(i);
            Button btn = optionsWordArray[i].gameObject.GetComponent<Button>();
            listButtonOptions.Add(btn);
            //  Debug.Log(btn.name);
        }
    }

    public void NextQuestion()
    {

        info.Add(new Results(auxListData[currentQuestionIndex].nameImage, correctAnswer));
        if (currentQuestionIndex < auxListData.Count - 1)
        {
            // Debug.Log(currentQuestionIndex);
            // Debug.Log(questionData.questions.Count);
            currentAnswerIndex++;
            currentQuestionIndex++;
            SetQuestion();
        }
        else
        {
            Debug.Log("Score: " + score);
            Invoke("Results", 1f);
        }

    }

    private void Results()
    {
        header.gameObject.SetActive(false);
        results.gameObject.SetActive(true);

        for (int i = 0; i < info.Count; i++)
        {
            string fulltext = (info[i].getName() + ":  " + info[i].getResult());
            listResults[i].gameObject.GetComponent<Text>().text = fulltext;
            //  Debug.Log(info[i].getName() + ": " + info[i].getResult());
        }

        Invoke("FinalMessage", 4f);
    }

    private void FinalMessage()
    {
        finalMessage.gameObject.SetActive(true);
        if (score < (auxListData.Count-3) * 50)
        {
            finalMessage.GetComponentInChildren<Transform>().GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            finalMessage.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(false);
        }
    }

    private void SetAudio()
    {
        AudioSource audioS;
        audioS = audioButton.GetComponent<AudioSource>();
        audioclip = auxListData[currentQuestionIndex].audio;
        audioS.clip = audioclip;
        audioButton.onClick.AddListener(() => PlayAudio(audioS));
    }

    private void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

}

[System.Serializable]
public class QuestionDatas
{
    public Sprite questionImage;
    public string nameImage;
    public AudioClip audio;
    public List<Sprite> answer;
    public List<int> key;

}

[System.Serializable]
public class OptionDatas
{
    public Sprite options;
}