using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAprende : MonoBehaviour
{
    private RectTransform subMenu;
    private float posFinal;
    private bool abrirMenu = true;
    private float tiempo = 0.5f;
    private Button btn;

    void Start()
    {
        subMenu = GameObject.FindGameObjectWithTag("SubMenu").GetComponent<RectTransform>();
        posFinal = Screen.width / 156;
        //Debug.Log("Antes:" + Screen.width + ":" + subMenu.position);
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, subMenu.position.z);
       // Debug.Log("Despues: " + -posFinal + " : " + subMenu.position);
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(moverBtn);
    }

    private void moverBtn()
    {
        float signo = 0;
        if (!abrirMenu)
        {
            signo = -1;
        }
        moverMenu(tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, subMenu.position.z));
        abrirMenu = !abrirMenu;
    }

    private void moverMenu(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(mover(time, posInit, posFin));
    }

    IEnumerator mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        subMenu.position = posFin;
    }
}


