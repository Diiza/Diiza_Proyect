using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BanderaNumeros : MonoBehaviour
{
    public static int bandera3;
    public void Numeros()
    {
        bandera3 = 1;
        SceneManager.LoadScene("MenuSustantivos");
    }
}
