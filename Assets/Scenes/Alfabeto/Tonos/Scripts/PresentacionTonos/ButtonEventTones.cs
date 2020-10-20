
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventTones : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ExecuteEvent);
    }

    private void ExecuteEvent()
    {
        ButtonsManagerTones.instance.Com(btn);
    }

    
}
