
using UnityEngine;
using UnityEngine.UI;

public class WordDatas : MonoBehaviour
{
    private Button buttonObj;

    private void Awake()
    {
        buttonObj = gameObject.GetComponent<Button>();

        if (buttonObj != null)
        {
            buttonObj.onClick.AddListener(() => CharSelected(buttonObj));
        }
    }

    private void CharSelected(Button btn)
    {
        QuizManage.instance.SelectedOption(btn);
    }

}

