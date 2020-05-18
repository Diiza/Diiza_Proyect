using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{
    public GameObject Bienvenida;
    public GameObject MenúPrincipal;
    
    public void OpenPanel()
    {
            Bienvenida.SetActive(false);
            MenúPrincipal.SetActive(true);
    }
 
}
