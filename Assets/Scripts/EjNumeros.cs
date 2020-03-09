using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjNumeros : MonoBehaviour
{
    public GameObject BtnSiguiente;
    public GameObject Menú;
    public GameObject Im14;
    public GameObject Im5;
    public GameObject Im4;
    public GameObject Im19;
    public GameObject Im18;
    public GameObject Im16;
    public GameObject Im17;
    public GameObject Im10;
    public GameObject Im12;
    public GameObject Im2;
    public GameObject Im9;
    public GameObject Im8;
    public GameObject Im11;
    public GameObject Im15;
    public GameObject Im6;
    public GameObject Im7;
    public GameObject Im13;
    public GameObject Im3;
    public GameObject Im1;
    public GameObject Im20;
    public int verificar=0;

    private void Update()
    {
        BtnSiguiente.SetActive(true);
    }
    public void SigNum()
    {
        verificar++;
        switch(verificar)
        {
            case 1:
                Im14.SetActive(false);
                Im5.SetActive(true);
                break;
            case 2:
                Im5.SetActive(false);
                Im4.SetActive(true);
                break;
            case 3:
                Im4.SetActive(false);
                Im19.SetActive(true);
                break;
            case 4:
                Im19.SetActive(false);
                Im18.SetActive(true);
                break;
            case 5:
                Im18.SetActive(false);
                Im16.SetActive(true);
                break;
            case 6:
                Im16.SetActive(false);
                Im17.SetActive(true);
                break;
            case 7:
                Im17.SetActive(false);
                Im10.SetActive(true);
                break;
            case 8:
                Im10.SetActive(false);
                Im12.SetActive(true);
                break;
            case 9:
                Im12.SetActive(false);
                Im2.SetActive(true);
                break;
            case 10:
                Im2.SetActive(false);
                Im9.SetActive(true);
                break;
            case 11:
                Im9.SetActive(false);
                Im8.SetActive(true);
                break;
            case 12:
                Im8.SetActive(false);
                Im11.SetActive(true);
                break;
            case 13:
                Im11.SetActive(false);
                Im15.SetActive(true);
                break;
            case 14:
                Im15.SetActive(false);
                Im6.SetActive(true);
                break;
            case 15:
                Im6.SetActive(false);
                Im7.SetActive(true);
                break;
            case 16:
                Im7.SetActive(false);
                Im13.SetActive(true);
                break;
            case 17:
                Im13.SetActive(false);
                Im3.SetActive(true);
                break;
            case 18:
                Im3.SetActive(false);
                Im1.SetActive(true);
                break;
            case 19:
                Im1.SetActive(false);
                Im20.SetActive(true);
                break;
            case 20:
                Im20.SetActive(false);
                Menú.SetActive(true);
                break;
        }
    }
}
