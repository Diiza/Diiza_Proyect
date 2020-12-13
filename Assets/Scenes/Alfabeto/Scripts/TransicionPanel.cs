using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransicionPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform subMenu;
    private float posFinal;
    private bool abrirMenu = true;
    [SerializeField]
    private float tiempo;
    private Button btn;

    void Start()
    {
        posFinal = Screen.width / 2;
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, subMenu.position.z);
        moverPanel();
    }

    private void moverPanel()
    {
        moverMenu(tiempo, subMenu.position, new Vector3(posFinal, subMenu.position.y, subMenu.position.z));
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


