using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName="ScriptableData" , menuName= "ScriptableData", order=1)]
public class ScriptableData : ScriptableObject
{
    public List<Data> listData;
}
