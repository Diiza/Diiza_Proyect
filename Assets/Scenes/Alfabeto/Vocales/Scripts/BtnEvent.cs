using UnityEngine.UI;
using UnityEngine;

public class BtnEvent : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ExecuteEvent);
    }

    private void ExecuteEvent()
    {
        ExamplesManager.instance.Com(btn);
    }
}
