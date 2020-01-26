using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Can edit it in the inspector
public class Dialogue
{
    [SerializeField] public string name;
     //Name of the Character or NPC
    [TextArea(3, 10)]
    [SerializeField] public string[] sentences; //Array of sentences


}
