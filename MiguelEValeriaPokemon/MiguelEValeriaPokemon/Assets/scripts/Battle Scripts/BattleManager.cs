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

    [Header("IN HERE I HAVE TO ADD ALL THE TEXTS AND SPRITES FOR THE PLAYER TRAINER AND MONSTER")]
    //player trainer Variables
    [SerializeField]
    TextMeshProUGUI playerTrainerNameText;
    [SerializeField]
    TextMeshProUGUI playerTrainerMonsterNameText;
    [SerializeField]
    Image playerTrainerMonsterHpBarImage;
    [SerializeField]
    Image playerTrainerMonsterSpriteImage;
    [Header("IN HERE I HAVE TO ADD ALL THE TEXTS AND SPRITES FOR THE ENEMY TRAINER AND MONSTER")]
    //Enemy trainer Variables
    [SerializeField]
    TextMeshProUGUI enemyTrainerNameText;
    [SerializeField]
    TextMeshProUGUI enemyTrainerMonsterNameText;
    [SerializeField]
    Image enemyTrainerMonsterHpBarImage;
    [SerializeField]
    Image enemyTrainerMonsterSpriteImage;



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

        //display the player trainer name
        playerTrainerNameText.text = playerTrainer.name;
        //display the player monster name
        playerTrainerMonsterNameText.text = playerTrainer.trainerMonsters[0].monster.name;
        //display the player monster hp
        playerTrainerMonsterHpBarImage.fillAmount = playerTrainer.trainerMonsters[0].monster.hp;
        //display the player monster sprite
        playerTrainerMonsterSpriteImage.sprite = playerTrainer.trainerMonsters[0].monster.image;

        //display the enemy trainer name
        enemyTrainerNameText.text = enemyTrainer.name;
        //display the enemy monster name
        enemyTrainerMonsterNameText.text = enemyTrainer.trainerMonsters[0].monster.name;
        //display the player monster hp
        enemyTrainerMonsterHpBarImage.fillAmount = 0.5f;
        //display the enemy monster sprite
        enemyTrainerMonsterSpriteImage.sprite = enemyTrainer.trainerMonsters[0].monster.image;


        //tell the code that the battle has started
        battleState = BattleState.start;
        
        Debug.Log("Battle Started");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
