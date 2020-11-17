using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARManager : MonoBehaviour, ITrackableEventHandler
{
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private List<SoData3D> modelsData;
    [SerializeField]
    private GameObject modelsDataGO;
    [SerializeField]
    private GameObject imageTargetGO;
    [SerializeField]
    private GameObject adviceGO;
    [SerializeField]
    private List<Button> optionButtons;
    [SerializeField]
    private List<GameObject> modelsContainers;
    [SerializeField]
    private GameObject buttonsPanelGO;
    [SerializeField]
    private GameObject arPanelGO;
    [SerializeField]
    private GameObject consItemGO;

    private AudioSource audioS;
    private TrackableBehaviour mTrackableBehaviour;
    private int modelsIndex;
    private Text sName;
    private Text zaName;
    private Button audioButton;
    private int indexModelsData;
    private Text consText;


    void Start()
    {
        modelsDataGO.gameObject.SetActive(false);
        sName = modelsDataGO.transform.GetChild(0).GetComponent<Text>();
        zaName = modelsDataGO.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        audioButton = modelsDataGO.transform.GetChild(1).GetComponent<Button>();
        audioS = audioButton.GetComponent<AudioSource>();

        consText = consItemGO.transform.GetChild(0).GetComponent<Text>();

        mTrackableBehaviour = imageTargetGO.GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        DisableModelsContainers();
        StartButtons();

    }

    private void DisableModelsContainers()
    {
        for (int i = 0; i < modelsContainers.Count; i++)
        {
            modelsContainers[i].SetActive(false);
        }

    }

    private void StartButtons()
    {
        int i = 0;
        foreach (var btn in optionButtons)
        {
            AddButtonsListener(btn, i);
            i++;
        }
    }

    private void AddButtonsListener(Button btn, int i)
    {
        btn.onClick.AddListener(() => SetData(btn, i));
    }

    private void SetData(Button btn, int k)
    {
        modelsIndex = 0;
        consText.text = btn.transform.GetChild(0).GetComponent<Text>().text;

        for (int i = 0; i < modelsContainers.Count; i++)
        {
            if (i == k)
            {
                modelsContainers[i].SetActive(true);
                Set3dModels(modelsContainers[i]);
                indexModelsData = i;
                SetModelData(modelsIndex);
            }
            else
            {
                modelsContainers[i].SetActive(false);
            }
        }

        buttonsPanelGO.gameObject.SetActive(false);
        arPanelGO.gameObject.SetActive(true);
    }


    private void Set3dModels(GameObject modelsContainer)
    {
        int childsGO = modelsContainer.transform.childCount;

        for (int i = 0; i < childsGO; i++)
        {
            models[i] = modelsContainer.transform.GetChild(i).gameObject;

            if (i == 0)
            {
                models[i].gameObject.SetActive(true);
            }
            else
            {
                models[i].gameObject.SetActive(false);
            }

        }

    }


    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            adviceGO.SetActive(false);
            modelsDataGO.gameObject.SetActive(true);

        }
        else
        {
            modelsDataGO.gameObject.SetActive(false);
            adviceGO.SetActive(true);
        }
    }


    public void ButtonClicked(RectTransform rtClicked)
    {
        if (rtClicked.name == "Previous")
        {
            PreviousModel();
        }

        else if (rtClicked.name == "Next")
        {
            NextModel();
        }
        else
        {
            arPanelGO.gameObject.SetActive(false);
            DisableModelsContainers();
            buttonsPanelGO.gameObject.SetActive(true);
        }

    }


    private void PreviousModel()
    {

        if (modelsIndex > 0)
        {
            models[modelsIndex].SetActive(false);
            models[--modelsIndex].SetActive(true);
            SetModelData(modelsIndex);
        }

    }


    private void NextModel()
    {
        if (modelsIndex < models.Count - 1)
        {
            models[modelsIndex].SetActive(false);
            models[++modelsIndex].SetActive(true);
            SetModelData(modelsIndex);
        }

    }


    private void SetModelData(int modelsIndex)
    {
        sName.text = modelsData[indexModelsData].modelsList[modelsIndex].nameEspanol;
        zaName.text = modelsData[indexModelsData].modelsList[modelsIndex].nameZapoteco;
        audioS.clip = modelsData[indexModelsData].modelsList[modelsIndex].audio;
        audioButton.onClick.AddListener(() => PlayAudio());
    }


    private void PlayAudio()
    {
        if (audioS != null)
        {
            audioS.Play();
        }
    }
}