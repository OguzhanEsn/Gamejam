using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class AIDialogue : ScriptableObject
{
    [TextArea(3, 10)] // Adjust the size of the text area in the inspector
    public string[] lines;
}
