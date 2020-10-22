using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableSprite", menuName = "ScriptableSprite", order = 1)]
public class ScriptableSprite : ScriptableObject
{
    public Sprite image;
    public AudioClip audio;
    public string nameZapoteco;
    public string nameEspanol;
}