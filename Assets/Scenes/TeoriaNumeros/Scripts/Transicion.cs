using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Transicion : MonoBehaviour
{
    [SerializeField] private GameObject Salir;
    public RectTransform subMenu;
    float posFinal;
    bool abrirMenu = true;
    public float tiempo = 0.5f;
    public static int bandera;
    void Start()
    {
        posFinal = Screen.width / 2;
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0);
    }

    IEnumerator Mover (float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        subMenu.position = posFin;
    }

    void MoverMenu (float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin));
    }

    public void ButtonMenu()
    {
        MoverMenu(tiempo, subMenu.position, new Vector3(1 * 540, subMenu.position.y, 0));
    }
    public void RegresaPanel()
    {
        MoverMenu(tiempo, subMenu.position, new Vector3(-1 * posFinal, subMenu.position.y, 0));
    }
    // Botones parte Teórica
    public void ButtonMenuTeorico()
    {
        MoverMenu(tiempo, subMenu.position, new Vector3(1 * posFinal, subMenu.position.y, 0));
        Salir.SetActive(false);
    }
    public void Atras()
    {
        MoverMenu(tiempo, subMenu.position, new Vector3(-1 * posFinal, subMenu.position.y, 0));
        Salir.SetActive(true);
    }
    public void BtnRegresar()
    {
        bandera = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }
    
}
