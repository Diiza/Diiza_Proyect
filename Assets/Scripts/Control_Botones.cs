using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control_Botones : MonoBehaviour
{
    public void MenuInicio() {
        SceneManager.LoadScene("Menu_Principal");
    }
}
