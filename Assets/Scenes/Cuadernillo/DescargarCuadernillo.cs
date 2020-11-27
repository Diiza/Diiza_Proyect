using UnityEngine.UI;
using UnityEngine;

public class DescargarCuadernillo : MonoBehaviour
{
    [SerializeField]
    private Button botonDescargar;
    [SerializeField]
    private string enlace;

    void Start()
    {
        botonDescargar.onClick.AddListener(Click);
    }

    private void Click()
    {
        Application.OpenURL(enlace);
    }

}
