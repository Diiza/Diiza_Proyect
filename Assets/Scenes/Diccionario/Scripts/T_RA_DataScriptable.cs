using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetsData", menuName = "TargetsData", order = 1)]
public class T_RA_DataScriptable : ScriptableObject
{
    public List<QuestionRA> questions;
}
