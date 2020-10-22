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
        if (ExamplesManager.instance != null)
        {
            ExamplesManager.instance.Com(btn);
        }

        if (ExaManager.instance != null)
        {
            ExaManager.instance.Com(btn);
        }
    }
}
