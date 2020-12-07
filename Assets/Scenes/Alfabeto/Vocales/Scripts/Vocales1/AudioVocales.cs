using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVocales : MonoBehaviour
{

    [SerializeField]
    private List<BtnAudios> Btns;

    void Start()
    {
        for (int i = 0; i < Btns.Count; i++)
        {
            for (int j = 0; j < Btns[i].listButtons.Count; j++)
            {

                Btns[i].listButtons[j].GetComponent<AudioSource>().clip = Btns[i].listAudios[j];
                AudioSource audio = Btns[i].listButtons[j].GetComponent<AudioSource>();
                Btns[i].listButtons[j].onClick.AddListener(() => ClickAudio(audio));
            }
        }
    }

    private void ClickAudio(AudioSource audio)
    {
        if (audio != null)
        {
            audio.Play();
        }
    }

}


[System.Serializable]
public class BtnAudios
{
    public List<Button> listButtons;
    public List<AudioClip> listAudios;
}
