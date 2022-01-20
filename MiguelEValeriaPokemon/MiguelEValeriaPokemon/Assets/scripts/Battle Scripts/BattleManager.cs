using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MasterClassExtensionMethod;
//this will create a enum that will save the current battle state
enum BattleState { start, playerTurn, enemyTurn, won, lost };

//this will make it mandatory for the battle manager to have a attackFunctionalities script
[RequireComponent(typeof(AttackFunctionalities))]
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

    //gets the attack Functionalities script
    AttackFunctionalities attackFunctionalitiesScript;

    //this will store the current monstar used by the player, it starts always from 0
    int currentPlayerMonster = 0;
    int currentEnemyMonster = 0;

    //this will store the initial hp of the enemy monster and 
    int startingPlayerHp = 0;
    int startingEnemyHp = 0;

    private void Start()
    {
        //assigns the script attack functionalities to the variable
        attackFunctionalitiesScript = this.gameObject.GetComponent<AttackFunctionalities>();

    }

    // this is called when the battle starts, and it setts up the battle
    public void StartBattle(TrainerBattleItemsAndMonsters enemyTrainer_)
    {
        //tell the code that the battle has started
        battleState = BattleState.start;
        
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
        //display the player monster sprite
        playerTrainerMonsterSpriteImage.sprite = playerTrainer.trainerMonsters[0].monster.image;

        //display the enemy trainer name
        enemyTrainerNameText.text = enemyTrainer.name;
        //display the enemy monster name
        enemyTrainerMonsterNameText.text = enemyTrainer.trainerMonsters[0].monster.name;
        //display the enemy monster sprite
        enemyTrainerMonsterSpriteImage.sprite = enemyTrainer.trainerMonsters[0].monster.image;

        //display the hp bar
        UpdateHpBar();

        //StartCoroutine(MasterClassExtensionMethod.RecallFunctionWhenSomethingHappen.WaitSecondsThenReturn(test, 2f));
        
        Debug.Log("Battle Started");

    
    }

    //this function will be called when an attack button is pressed
    public void OnAttack(int buttonPressedIndex)
    {
        Debug.Log("The attack " + playerTrainer.trainerMonsters[currentPlayerMonster].attacks[buttonPressedIndex].name +" was pressed" );
        //sends the information about the attack,it sends the attack, the player monster, enemy monster and a boolean that is true if it was the player attacking
        attackFunctionalitiesScript.ReceiveInformationAboutTheAttack(playerTrainer.trainerMonsters[currentPlayerMonster].attacks[buttonPressedIndex], playerTrainer.trainerMonsters[currentPlayerMonster], enemyTrainer.trainerMonsters[currentEnemyMonster], true);
    }

    //this function is called by the attack functionalities and its used to give damage, the playerAttacked Boolean is true if its the player attacking and false if its the enemy attacking
    public void GiveDamage(float hpLeft, bool playerAttacked)
    {
        //if the player has attacked
        if(playerAttacked==true)
        {
            enemyTrainer.trainerMonsters[currentEnemyMonster].currentHp = (int)hpLeft;
            UpdateHpBar();
        }
        //if the enemy has attacked
        else 
        {
            playerTrainer.trainerMonsters[currentPlayerMonster].currentHp = (int)hpLeft;
            UpdateHpBar();
        }
    }

    void UpdateHpBar()
    {
        /*
         * THE FORMULA TO DO THE PERCENTAGE FOR THE HP IS :
         * y = currentX/maxX; y = y * 100; y = y / 100;
         * */

        //the percentageOfHp will be used to get the percent of the hp, on the formula this is the y
        float percentageOfHp;

        /*START OF UPDATING THE PLAYER HP BAR*/
        percentageOfHp = (float)playerTrainer.trainerMonsters[currentPlayerMonster].currentHp / (float)playerTrainer.trainerMonsters[currentPlayerMonster].ReturnMonsterHp();
        percentageOfHp = percentageOfHp * 100;
        percentageOfHp = percentageOfHp / 100;
        playerTrainerMonsterHpBarImage.fillAmount = percentageOfHp;
        /*END OF UPDATING THE PLAYER HP BAR*/

        percentageOfHp = 0.0f; //reset the variable to reuse it for the enemy

        /*START OF UPDATING THE ENEMY HP BAR*/
        percentageOfHp = (float)enemyTrainer.trainerMonsters[currentEnemyMonster].currentHp / (float)enemyTrainer.trainerMonsters[currentEnemyMonster].ReturnMonsterHp();
        percentageOfHp = percentageOfHp * 100;
        percentageOfHp = percentageOfHp / 100;
        enemyTrainerMonsterHpBarImage.fillAmount = percentageOfHp;
        /*END OF UPDATING THE ENEMY HP BAR*/
    }

    void test()
    {
        Debug.Log("it waited f seconds and returned on battle manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
