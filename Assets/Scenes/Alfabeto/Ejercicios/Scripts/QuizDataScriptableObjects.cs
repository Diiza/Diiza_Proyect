
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

[CreateAssetMenu(fileName = "QuestionD", menuName = "QuestionD", order = 1)]

public class QuizDataScriptableObjects : ScriptableObject
{
    public List<QuestionDatas> questions;
    public List<OptionDatas> options;

}
