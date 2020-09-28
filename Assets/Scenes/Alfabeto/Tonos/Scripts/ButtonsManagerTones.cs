using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManagerTones : MonoBehaviour
{
    public static ButtonsManagerTones instance;
    [SerializeField]
    private ScriptableTones soData;
    [SerializeField]
    private List<Button> listButtons = new List<Button>();
    private AudioSource audioSource;
    private Animator animator;


    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        SetSprites();

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

        playAudio(btn);
    }

    private void playAudio(Button btn)
    {
        AudioSource audioS = btn.GetComponent<AudioSource>();
        animator=btn.GetComponent<Animator>();
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

        animator.Play("AnimBoton", 0, 0.25f);

    }
}
