
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ExecuteEvent);
    }

    private void ExecuteEvent()
    {
        ButtonsManager.instance.Com(btn);
    }

    
}
