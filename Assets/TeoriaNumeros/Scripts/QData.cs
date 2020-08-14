using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DatosPreguntas", menuName = "DatosPreguntas", order = 1)]
public class QData : ScriptableObject
{
    public List<Pregunta> questions;
}
