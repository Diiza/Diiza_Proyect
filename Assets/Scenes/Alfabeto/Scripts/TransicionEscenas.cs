
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransicionEscenas : MonoBehaviour
{

    [SerializeField] private string nomEscena;
    private Button btn;
    
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(cambioEscena);
    }

    private void cambioEscena()
    {
        SceneManager.LoadScene(nomEscena);
    }
}
