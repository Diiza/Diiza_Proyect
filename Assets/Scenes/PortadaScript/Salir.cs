using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salir : MonoBehaviour
{
    [SerializeField]
    private Button btnSalir;

    void Start()
    {
        btnSalir.onClick.AddListener(SalirApp);
    }

    private void SalirApp()
    {
        Application.Quit();
    }
}
