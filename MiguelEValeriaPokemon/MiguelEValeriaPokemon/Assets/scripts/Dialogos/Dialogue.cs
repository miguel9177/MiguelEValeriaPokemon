using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "MiguelThings/Dialogue")]
public class Dialogue : ScriptableObject {
    [TextArea(3, 20)]
    public string dialogue;
    public bool choiceDialogue;
    public bool fightDialogue;

   

 

}
