using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Transicion transicion;
    [SerializeField] private OpenPanel panelopen;
    [SerializeField] private GameObject PrincipalMenu, SMenu, MenuJuegos;
    [SerializeField] private List<Button> options;
    [SerializeField] private List<Button> uiButtons;
    //[SerializeField] private Text encabezado1, encabezado2;
#pragma warning restore 649
    private Animator animador;
    public static int tecla;

    private void Start()
    {
        //add the listner to all the buttons
        if (Transicion.bandera == 1)
        {
            PrincipalMenu.SetActive(false);
            SMenu.SetActive(true);
            transicion.ButtonMenu();
            Transicion.bandera = 0;
        }
        if (BtnAtrasMenuJuegos.bandera2 == 1)
        {
            PrincipalMenu.SetActive(false);
            MenuJuegos.SetActive(true);
            panelopen.ButtonMenu();
            BtnAtrasMenuJuegos.bandera2 = 0;
        }
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClic(localBtn, tecla));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => Animacion(localBtn));
            localBtn.onClick.AddListener(() => OneClick(localBtn));
        }

    }
    /// <summary>
    /// Method assigned to the buttons
    /// </summary>
    /// <param name="btn">ref to the button object</param>
    void OneClick(Button btn)
    {
        
        switch (btn.name)
        {
            case "BtnAlfabeto":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 1;
                break;
            case "BtnNumeros":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 2;
                break;
            case "BtnCuerpo":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 3;
                break;
            case "BtnCasa":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 4;
                break;
            case "BtnPAnimales":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 5;
                Debug.Log(tecla);
                break;
            case "BtnArbol":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 6;
                Debug.Log(tecla);
                break;
            case "BtnAnimales":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 7;
                break;
            case "BtnFrutas":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 8;
                break;
            case "BtnCosas":
                PrincipalMenu.SetActive(false);
                SMenu.SetActive(true);
                tecla = 9;
                break;
        }
    }
   
    void OnClic(Button btn, int botont)
    {
        //Debug.Log(tecla);
        switch (btn.name)
        {
            case "Aprende":
                if (botont == 1)
                {
                    Escena("Alfabeto");
                }
                if (botont == 2)
                {
                    Escena("TeoriaNumeros");

                }
                if (botont == 3)
                {
                    Escena("TeoriaCuerpo");
                }
                if (botont == 4)
                {
                    Escena("PartesCasa");
                }
                if (botont == 5)
                {
                    Escena("PartesAnimales");
                }
                if (botont == 6)
                {
                    Escena("PartesArbol");
                }
                break;
            case "Practica":
                
                SMenu.SetActive(false);
                MenuJuegos.SetActive(true);
                break;
        }
    }
    
    public void RestryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Animacion(Button localBtn)
    {
        animador = localBtn.animator; ;
        animador.Play("AnimBoton", 0, 0.25f);
    }

    public void Escena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
