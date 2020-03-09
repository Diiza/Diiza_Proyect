using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{
    public GameObject Bienvenida;
    public GameObject Menú;
    public GameObject MenúPrincipal;
    public GameObject BtnSiguiente;
    public int alfabeto = 0, numeros = 0, plantas = 0, animales = 0, hogar = 0, emociones = 0, familia = 0, cuerpo = 0, ropa = 0, oraciones = 0;

    // Update is called once per frame
    void Update()
    {
        BtnSiguiente.SetActive(false);
    }
    public void OpenPanel()
    {
            Bienvenida.SetActive(false);
            MenúPrincipal.SetActive(true);
    }
    public void PanelAlfabeto()
    {
        alfabeto = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelNum()
    {
        numeros = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
        Debug.Log("ENTRA AL MENU");
        Debug.Log(numeros);
    }
    public void PanelPlantas()
    {
        plantas = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelAnimales()
    {
        animales = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelHogar()
    {
        hogar = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelEmociones()
    {
        emociones = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelFamilia()
    {
        familia = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelCuerpo()
    {
        cuerpo = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelRopa()
    {
        ropa = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void PanelOraciones()
    {
        oraciones = 1;
        MenúPrincipal.SetActive(false);
        Menú.SetActive(true);
    }
    public void Regresar()
    {
        alfabeto = 0; numeros = 0; plantas = 0; animales = 0; hogar = 0; emociones = 0; familia = 0; cuerpo = 0; ropa = 0; oraciones = 0;
        MenúPrincipal.SetActive(true);
        Menú.SetActive(false);

    }
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    
}
