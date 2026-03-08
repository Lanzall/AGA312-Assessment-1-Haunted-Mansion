using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string name;         // Name of the character speaking

    [TextArea(3, 10)]
    public string[] sentences;    // Array to hold the sentences of the dialogue
}
