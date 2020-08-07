using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnAR : MonoBehaviour
{
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn=this.GetComponent<Button>();
        btn.onClick.AddListener(EscenaAR);
    }

    private void EscenaAR(){
        SceneManager.LoadScene("ARVocales");
    }
}
