using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string Name;
    [TextArea(3,5)]
    public string[] DialogueText;
}
