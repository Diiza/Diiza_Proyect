using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamplesManager : MonoBehaviour
{
    [SerializeField]
    private List<Button> rulesList;
    [SerializeField]
    private List<ScriptableExamples> dataExamples;
    [SerializeField]
    private List<ItemExamples> ContentPanelExample;
    [SerializeField]
    private GameObject panelExamples;
    [SerializeField]
    private Text ruleHeader;
    [SerializeField]
    private GameObject Scroll;
    private Vector3 scrollStartPosition;


    public static ExamplesManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

    }

    void Start()
    {
        panelExamples.SetActive(false);
        scrollStartPosition = Scroll.GetComponent<RectTransform>().position;
    }

    public void Com(Button btn)
    {
        Scroll.GetComponent<RectTransform>().position = scrollStartPosition;
        loadDataPanel(btn);
        panelExamples.SetActive(true);
    }

    private void loadDataPanel(Button btn)
    {
        ruleHeader.text = btn.GetComponentInChildren<Transform>().GetChild(0).GetComponent<Text>().text;

        for (int i = 0; i < rulesList.Count; i++)
        {
            if (btn.name == rulesList[i].name)
            {

                for (int j = 0; j < ContentPanelExample.Count; j++)
                {
                    ContentPanelExample[j].imageExample.sprite = dataExamples[i].scriptableList[j].image;
                    ContentPanelExample[j].btnExample.GetComponent<AudioSource>().clip = dataExamples[i].scriptableList[j].audio;
                    ContentPanelExample[j].nameExample.text = dataExamples[i].scriptableList[j].name;

                    AudioSource audio = ContentPanelExample[j].btnExample.GetComponent<AudioSource>();
                    if (audio != null)
                    {
                        ContentPanelExample[j].btnExample.onClick.AddListener(() => playAudio(audio));
                    }

                }

            }
        }
    }

    public void playAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void DisablePanel()
    {
        panelExamples.SetActive(false);
    }

}

[System.Serializable]
public class ItemExamples
{
    public Image imageExample;
    public Button btnExample;
    public Text nameExample;
}

[System.Serializable]
public class ExampleD
{
    public Sprite image;
    public AudioClip audio;
    public string name;

}

