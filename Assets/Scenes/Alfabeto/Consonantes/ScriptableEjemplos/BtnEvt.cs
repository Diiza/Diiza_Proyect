using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEv : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ExecuteEvent);
    }

    private void ExecuteEvent()
    {
        ExaManager.instance.Com(btn);
    }
}
