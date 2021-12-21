using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
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
                //show the battle canvas
                player.uiManager.ShowBattleCanvas();
                //Start the battle
                this.gameObject.GetComponent<BattleInitializer>().StartBattle();
                
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
