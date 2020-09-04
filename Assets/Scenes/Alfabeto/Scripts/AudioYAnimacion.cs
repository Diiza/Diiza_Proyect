using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class AudioYAnimacion : MonoBehaviour
{
    private Transform transformCo; //Para guardar cantidad de Transform de hijos
    private Transform[] hijoTransform;//Almacena los Transoform hijos
    private Button[] botones; //Almacena componente Button de hijos
    private Animator anim;
    private new AudioSource audio;


    void Start()
    {
        transformCo = GetComponentInChildren<Transform>();//Obtener # de transform Hijos
        hijoTransform = new Transform[transformCo.childCount];//Inicializacion de vec.
        botones = new Button[transformCo.childCount];//Inicializacion de vec.
        obtenerGoHijos();
    }

    private void obtenerGoHijos()
    {
        for (int i = 0; i < transformCo.childCount; i++)
        {
            hijoTransform[i] = transform.GetChild(i);//Guarda los transform hijos
            botones[i] = hijoTransform[i].gameObject.GetComponent<Button>();//Guarda Comp. Button de gO hijos
            Button btn = botones[i];//Crea y asigna Boton por cada gO hijo
            btn.onClick.AddListener(() => animacionesYAudios(btn));//Llamda a metodo
        }
    }

    private void animacionesYAudios(Button btn)
    {
        anim = btn.animator; ;
        anim.Play("AnimBoton", 0, 0.25f);
        audio = btn.GetComponent<AudioSource>();
        if (audio != null)
            audio.Play();
    }
}
