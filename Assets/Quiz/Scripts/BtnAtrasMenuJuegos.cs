using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnAtrasMenuJuegos : MonoBehaviour
{
    public static int bandera2;

    public void RestryButton()
    {
        bandera2 = 1;
        SceneManager.LoadScene("MenuPrincipal");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Escena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

}
