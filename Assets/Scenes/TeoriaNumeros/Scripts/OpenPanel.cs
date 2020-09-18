using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] private List<Button> salir;
    [SerializeField] private GameObject PrincipalMenu, SMenu, MenuJuegos;
    public RectTransform subMenu;
    public RectTransform subMenu2;
    float posFinal;
    bool abrirMenu = true;
    public float tiempo = 0.5f;
    void Start()
    {
        for (int i = 0; i < salir.Count; i++)
        {
            Button localBtn = salir[i];
            localBtn.onClick.AddListener(() => Click(localBtn));
        }

        posFinal = Screen.width / 2;
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0);
        subMenu2.position = new Vector3(-posFinal, subMenu2.position.y, 0);
    }

    IEnumerator Mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            //subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            subMenu2.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        subMenu2.position = posFin;
        //subMenu.position = posFin;
    }

    IEnumerator MoverPanel(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            //subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        subMenu.position = posFin;
        //subMenu.position = posFin;
    }

    void MoverMenu(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin));
    }

    void MoverMenu2(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(MoverPanel(time, posInit, posFin));
    }

    public void ButtonMenu()
    {
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0);
        MoverMenu(tiempo, subMenu2.position, new Vector3(1 * posFinal, subMenu2.position.y, 0));
        //abrirMenu = !abrirMenu;
    }
    void Click(Button btn)
    {

        switch (btn.name)
        {
            case "SalirMP":
                MoverMenu2(tiempo, subMenu.position, new Vector3(-1 * posFinal, subMenu.position.y, 0));
                MoverMenu(tiempo, subMenu2.position, new Vector3(-1 * posFinal, subMenu2.position.y, 0));
                SMenu.SetActive(false);
                PrincipalMenu.SetActive(true);
                break;
            case "SalirSM":
                MoverMenu(tiempo, subMenu2.position, new Vector3(-1 * posFinal, subMenu2.position.y, 0));
                MoverMenu2(tiempo, subMenu.position, new Vector3(1 * posFinal, subMenu.position.y, 0));
                MenuJuegos.SetActive(false);
                SMenu.SetActive(true);
                break;

        }
    }
}
