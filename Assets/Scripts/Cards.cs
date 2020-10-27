using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class Cards : ScriptableObject
{
    [TextArea]public string decision;
    [TextArea]public string textOption1;
    [TextArea]public string textOption2;

    [Header("Mensajes opcion 1")]
    public string message1;
    public float amount1;
    public string message2;
    public float amount2;

    [Header("Mensajes opcion 2")]
    public string message3;
    public float amount3;
    public string message4;
    public float amount4;
}
