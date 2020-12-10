using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuAdm : MonoBehaviour
{
    private Transform transformCo; //Para guardar cantidad de Transform de hijos
    private Transform[] hijoTransform;//Almacena los Transoform hijos
    private Button[] botones; //Almacena componente Button de hijos

    void Start()
    {
        transformCo = GetComponentInChildren<Transform>();//Obtener # de transform Hijos
        Debug.Log(transformCo.childCount); //Imprime transform hijos
        hijoTransform = new Transform[transformCo.childCount];//Inicializacion de vec.
        botones = new Button[transformCo.childCount];//Inicializacion de vec.
        obtenerGoHijos();
    }

    private void obtenerGoHijos()
    {
        for (int i = 0; i < transformCo.childCount; i++)
        {
            hijoTransform[i] = transform.GetChild(i);//Guarda los transform hijos
            Debug.Log(hijoTransform[i].gameObject.name);//Imprime nombre de gO hijos

            botones[i] = hijoTransform[i].gameObject.GetComponent<Button>();//Guarda Comp. Button de gO hijos
            Button btn = botones[i];//Crea y asigna Boton por cada gO hijo
            btn.onClick.AddListener(() => opcionesMenu(btn));//Llamda a metodo
        }
    }

    private void opcionesMenu(Button boton)
    {
        switch (boton.name)
        {//Depende del nombre de los GO boton
            case "BtnVocales":
                SceneManager.LoadScene("Vocales1");
                Debug.Log("Escena: Vocales");
                break;
            case "BtnConsonantes":
                SceneManager.LoadScene("Consonantes1");
                Debug.Log("Escena: Consonantes");
                break;
            case "BtnTonos":
                SceneManager.LoadScene("Tonos1");
                Debug.Log("Escena: Tonos");
                break;
        }
    }
}
