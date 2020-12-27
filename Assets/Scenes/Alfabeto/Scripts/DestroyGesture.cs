using UnityEngine;
using UnityEngine.UI;
public class DestroyGesture : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    void Start()
    {
        btn.onClick.AddListener(DestroyIcon);
    }

    private void DestroyIcon()
    {
         Destroy(gameObject);
    }
}
