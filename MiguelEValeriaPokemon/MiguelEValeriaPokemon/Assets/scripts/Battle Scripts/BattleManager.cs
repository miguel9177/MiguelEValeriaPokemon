using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this will create a enum that will save the current battle state
enum BattleState { start, playerTurn, enemyTurn, won, lost };
public class BattleManager : MonoBehaviour
{   /// <summary>
    ///THIS PART OF THE CODE IS TO GET THE UI ELEMENTS 
    /// </summary>
    [SerializeField]
    TextMeshProUGUI[] textAttacks;
    [SerializeField]
    TextMeshProUGUI[] textSpecialAttack;

    


    //this will store both trainers fighting
    TrainerBattleItemsAndMonsters enemyTrainer;
    //this will store the user trainer
    [SerializeField]
    TrainerBattleItemsAndMonsters playerTrainer;

    //create a new battle state
    BattleState battleState;

   

    // this is called when the battle starts, and it setts up the battle
    public void StartBattle(TrainerBattleItemsAndMonsters enemyTrainer_)
    {
        
        //settup the enemy trainer
        enemyTrainer = enemyTrainer_;

        //this for will write the attacks on the textboxes
        for(int i=0; i<textAttacks.Length; i++)
        {
            if(playerTrainer.trainerMonsters[0].attacks.Length>i)
            {
                textAttacks[i].text = playerTrainer.trainerMonsters[0].attacks[i].name;
            }
        }

        

        //tell the code that the battle has started
        battleState = BattleState.start;
        
        Debug.Log("Battle Started");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
