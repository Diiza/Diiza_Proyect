using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager instance;
    [SerializeField]
    private ScriptableData soData;
    [SerializeField]
    private List<Button> listButtons = new List<Button>();
    [SerializeField]
    private GameObject information;
    [SerializeField]
    private Image imageLetter;
    [SerializeField]
    private Button audioLetter;
    [SerializeField]
    private Image imageExample1;
    [SerializeField]
    private Image imageExample2;
    [SerializeField]
    private GameObject nameExample1;
    [SerializeField]
    private GameObject nameExample2;
    [SerializeField]
    private GameObject nameSpa1;
    [SerializeField]
    private GameObject nameSpa2;
    [SerializeField]
    private Button audioExample1;
    [SerializeField]
    private Button audioExample2;
    private AudioSource audioSource;
    private AudioSource audio1;
    private AudioSource audio2;
    private Image img1;
    private Image img2;
    private Text name1;
    private Text name2;
    private Text nameS1;
    private Text nameS2;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        SetSprites();
        audioSource = audioLetter.GetComponent<AudioSource>();
        audio1 = audioExample1.GetComponent<AudioSource>();
        audio2 = audioExample2.GetComponent<AudioSource>();
        img1 = imageExample1.GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
        img2 = imageExample2.GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
        name1 = nameExample1.GetComponentInChildren<Transform>().GetChild(0).GetComponent<Text>();
        name2 = nameExample2.GetComponentInChildren<Transform>().GetChild(0).GetComponent<Text>();
        nameS1 = nameSpa1.GetComponent<Text>();
        nameS2 = nameSpa2.GetComponent<Text>();
        information.gameObject.SetActive(false);

    }

    private void SetSprites()
    {
        for (int i = 0; i < listButtons.Count; i++)
        {
            Image img = listButtons[i].GetComponentInChildren<Transform>().GetChild(0).GetComponent<Image>();
            img.sprite = soData.listData[i].image;
        }
    }

    public void Com(Button btn)
    {
        SpawnInformation();
        playAudio(btn);
        setInformation(btn);
    }

    private void SpawnInformation()
    {
        information.gameObject.SetActive(true);
    }

    private void playAudio(Button btn)
    {
        AudioSource audioS = btn.GetComponent<AudioSource>();

        for (int i = 0; i < listButtons.Count; i++)
        {
            if (btn.name == listButtons[i].name)
            {
                audioS.clip = soData.listData[i].audio;
                break;
            }
        }
        if (audioS != null)
        {
            audioS.Play();
        }

    }

    private void setInformation(Button btn)
    {
        for (int i = 0; i < listButtons.Count; i++)
        {
            if (btn.name == listButtons[i].name)
            {
                imageLetter.sprite = soData.listData[i].image;
                img1.sprite = soData.listData[i].example[0].image;
                img2.sprite = soData.listData[i].example[1].image;
                name1.text = soData.listData[i].example[0].nameZapoteco;
                name2.text = soData.listData[i].example[1].nameZapoteco;
                nameS1.text = soData.listData[i].example[0].nameEspanol;
                nameS2.text = soData.listData[i].example[1].nameEspanol;
                audio1.clip = soData.listData[i].example[0].audio;
                audio2.clip = soData.listData[i].example[1].audio;
                audioLetter.onClick.AddListener(() => letterAudio(i));
                break;
            }
        }
        audioExample1.onClick.AddListener(() => playExamples(audio1));
        audioExample2.onClick.AddListener(() => playExamples(audio2));
    }

    private void letterAudio(int i)
    {
        audioSource.clip = soData.listData[i].audio;
        if (audioSource != null)
        {
            audioSource.Play();
        }

    }


    private void playExamples(AudioSource audio)
    {
        if (audio != null)
        {
            audio.Play();
        }

    }

    public void backButton()
    {
        audioLetter.GetComponent<AudioSource>().clip=null; //Resetear audio de letra
        information.gameObject.SetActive(false);
    }

}
