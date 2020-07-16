using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class Correcto : MonoBehaviour
{
    public AudioClip sound;
    private Button button {  get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        button.onClick.AddListener(() => PlaySound());
    }
    
    public void PlaySound()
    {
        int b = 1;
        int escena = Random.Range(3, 22);
        int i;
        SceneManager.LoadScene(escena);
        source.PlayOneShot(sound);

        for (i = 0; i <= 500; i++)
        {
            Debug.Log(i);
        }
    }
    public void repeticiones(int b)
    {
        int a;
        a = b + b;
    }
}