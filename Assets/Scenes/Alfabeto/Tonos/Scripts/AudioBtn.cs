
using UnityEngine;
using UnityEngine.UI;

public class AudioBtn : MonoBehaviour
{
    [SerializeField]
    private Button audioBtn;
    void Start()
    {
        AudioSource audio;
        audio = audioBtn.GetComponent<AudioSource>();
        audioBtn.onClick.AddListener(() => playAudio(audio));
    }

    private void playAudio(AudioSource audio)
    {
        if (audio)
        {
            audio.Play();
        }
    }
}
