using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPaneles : MonoBehaviour
{
    [SerializeField] private Button goBtn1;
    [SerializeField] private Button goBtn2;
    [SerializeField] private Button goBtn3;
    [SerializeField] private Button goBtn4;
    private GameObject goPanel1;
    private GameObject goPanel2;
    private GameObject goPanel3;
    private GameObject goPanel4;

    private void Start()
    {
        obtenerPaneles();
        obtenerBotones();
        capturarEventos();
    }

    private void obtenerPaneles()
    {
        goPanel1 = GameObject.FindGameObjectWithTag("VocalesGramPanel1");
        goPanel2 = GameObject.FindGameObjectWithTag("VocalesGramPanel2");
        goPanel3 = GameObject.FindGameObjectWithTag("VocalesGramPanel3");
        goPanel4 = GameObject.FindGameObjectWithTag("VocalesGramPanel4");
    }

    private void obtenerBotones()
    {
        goBtn1 = goBtn1.GetComponent<Button>();
        goBtn2 = goBtn2.GetComponent<Button>();
        goBtn3 = goBtn3.GetComponent<Button>();
        if (goBtn4 != null)
            goBtn4 = goBtn4.GetComponent<Button>();
    }

    private void capturarEventos()
    {
        goBtn1.onClick.AddListener(activarPanel1);
        goBtn2.onClick.AddListener(activarPanel2);
        goBtn3.onClick.AddListener(activarPanel3);
        if (goBtn4 != null)
            goBtn4.onClick.AddListener(activarPanel4);
    }

    private void activarPanel1()
    {
        goPanel1.SetActive(true);
        goPanel2.SetActive(false);
        goPanel3.SetActive(false);
        if (goBtn4 != null)
            goPanel4.SetActive(false);
    }
    private void activarPanel2()
    {
        goPanel1.SetActive(false);
        goPanel2.SetActive(true);
        goPanel3.SetActive(false);
        if (goBtn4 != null)
            goPanel4.SetActive(false);
    }
    private void activarPanel3()
    {
        goPanel1.SetActive(false);
        goPanel2.SetActive(false);
        goPanel3.SetActive(true);
        if (goBtn4 != null)
            goPanel4.SetActive(false);
    }

    private void activarPanel4()
    {
        goPanel1.SetActive(false);
        goPanel2.SetActive(false);
        goPanel3.SetActive(false);
        if (goBtn4 != null)
            goPanel4.SetActive(true);
    }

}
