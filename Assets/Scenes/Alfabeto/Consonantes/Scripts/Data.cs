using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public Sprite image;
    public AudioClip audio;
    public List<Example> example;
}

[System.Serializable]
public class Example
{
    public Sprite imageExample;
    public string nameExample;
    public AudioClip audioExample;
}
