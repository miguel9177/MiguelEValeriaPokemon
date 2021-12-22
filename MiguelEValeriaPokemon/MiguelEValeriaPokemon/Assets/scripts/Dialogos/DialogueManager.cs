using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{   
    [Header("IF THIS DIALOGUE IS GOING TO HAVE A BATTLE THIS GAMEOBJECT NEEDS A BattleInitializer SCRIPT")]
    [SerializeField]
    //this will store the chats for this npcs
    Dialogue[] NpcChat;
    //this is going to store on what chat item we are
    int currentNpcChat;
    //this will store the ui displaying the text, i use the textmeshprougui because its a much better solution then the text ui from unity
    [SerializeField]
    TextMeshProUGUI textToChange;

    

    // Update is called once per frame
    public void NextDialogue(PlayerMovement player)
    {
        
        textToChange.gameObject.SetActive(true);
        player.uiManager.OnlyShowActionButton();
        //if we didnt reach the last item on the dialogue array
        if (currentNpcChat<NpcChat.Length)
        {
            //if its not a fight dialogue
            if(NpcChat[currentNpcChat].fightDialogue == false)
            {
                //Change the text of the ui
                textToChange.text = NpcChat[currentNpcChat].dialogue; 
            }
            //if its a fight dialogue
            else if (NpcChat[currentNpcChat].fightDialogue == true)
            {
                //Change the text of the ui
                textToChange.text = NpcChat[currentNpcChat].dialogue;
                //this will check if the npc has a battle initializer script, i do this to avoid errors in case i forget to add a battle initializer to this object
                if(this.gameObject.GetComponent<BattleInitializer>() == true)
                {
                    //Start the battle
                    this.gameObject.GetComponent<BattleInitializer>().StartBattle();
                    //show the battle canvas
                    player.uiManager.ShowBattleCanvas();
                }
                else
                {
                    //hide the text
                    textToChange.gameObject.SetActive(false);
                    currentNpcChat = 0;
                    player.uiManager.ShowPlayerCanvas();
                    Debug.LogWarning("THE NPC " + this.name + " PROBABLY NEEDS A BATTLE INITIALIZER, SINCE IT HAS A DIALOGUE THAT STARTS A BATTLE");
                }

            }
            currentNpcChat += 1;
        }
        //if we reach the last text
        else
        {
            //hide the text
            textToChange.gameObject.SetActive(false);
            currentNpcChat = 0;
            player.uiManager.ShowPlayerCanvas();
        }
    }
}
