using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will make it mandatory for the battle manager to have a attackFunctionalities script
[RequireComponent(typeof(BattleManager))]
public class AttackFunctionalities : MonoBehaviour
{
    //THIS SCRIPT IS THE ONE WHOS GOING TO DO ALL OF THE ATTACKING FUNCTIONALITY, IT WILL RECEIVE AN ATTACK AND THEN DO THE PROCESSING OF GIVING DAMAGE as

    public Animator animator;

    //this will store the batle manager script, and this variable is assigned in void start
    BattleManager battlemanager;

    private void Start()
    {
        battlemanager = this.gameObject.GetComponent<BattleManager>();
    }

    //this script is called by the battleManager, when an attack is chosen, it receives the attack used, the player monster, enemy monster and if it was the player attacking or the enemy
    public void ReceiveInformationAboutTheAttack(Attacks attack, TrainerBattleItemsAndMonsters.TrainerMonsters playerMonster, TrainerBattleItemsAndMonsters.TrainerMonsters enemyMonster, bool playerAttacked)
    {
        //if the type of attack is damage type call the damage function
        if (attack.typeOfAttack == TypeOfAttack.damage)
        {
            //call the function that does the functionality for the attack
            AttackDamage(attack, playerMonster, enemyMonster, playerAttacked);
        }
    }

    //this receives the attack used, the player monster, enemy monster and if it was the player attacking or the enemy, and does the functionality for it
    void AttackDamage(Attacks attack, TrainerBattleItemsAndMonsters.TrainerMonsters playerMonster, TrainerBattleItemsAndMonsters.TrainerMonsters enemyMonster, bool playerAttacked)
    {
        /*
         * THE FORMULA FOR THE ATTACK IS 
         * X=ATTACK_CHOSEN/3;     X=X*ATTACK;   X=X/DEF_ENEMY;  X=HP-(X*EFFECTIVNESS);
         * */

        //this variable will be used to do the maths, and it will save the hp left on the enemy or player
        float hpLeft = 0;

        //if it was the player attacking
        if(playerAttacked == true)
        {
            //start applaying the formula by dividing the attack by 3
            hpLeft = attack.damage / 3;

            //if the attack is ranged
            if(attack.damageType==AttackDamageType.rangeType)
            {
                //multiply the variable by the player damage stat
                hpLeft = hpLeft * playerMonster.ReturnMonsterRangeDamage();
                //divide the variable by the enemy defense
                hpLeft = hpLeft / enemyMonster.ReturnMonsterRangeDefense();
            }
            //if the attack is melee
            else
            {
                //multiply the variable by the player damage stat
                hpLeft = hpLeft * playerMonster.ReturnMonsterMeleeDamage();
                //divide the variable by the enemy defense
                hpLeft = hpLeft / enemyMonster.ReturnMonsterMeleeDefense();
            }

            //do the last part of the formula, first multiply the effectivness of the attack by the variable, and then subtract the enemy hp by the variable
            hpLeft = enemyMonster.currentHp - (hpLeft * ReturnEffectiveness(attack.attackElement,enemyMonster.monster.type, true));
            //this will give the damage
            battlemanager.GiveDamage(hpLeft, true);
        }
        //if its the enemy attacking
        else
        {
            //start applaying the formula by dividing the attack by 3
            hpLeft = attack.damage / 3;

            //if the attack is ranged
            if (attack.damageType == AttackDamageType.rangeType)
            {
                //multiply the variable by the player damage stat
                hpLeft = hpLeft * enemyMonster.ReturnMonsterRangeDamage();
                //divide the variable by the enemy defense
                hpLeft = hpLeft / playerMonster.ReturnMonsterRangeDefense();
            }
            //if the attack is melee
            else
            {
                //multiply the variable by the player damage stat
                hpLeft = hpLeft * enemyMonster.ReturnMonsterMeleeDamage();
                //divide the variable by the enemy defense
                hpLeft = hpLeft / playerMonster.ReturnMonsterMeleeDefense();
            }

            //do the last part of the formula, first multiply the effectivness of the attack by the variable, and then subtract the enemy hp by the variable
            hpLeft = playerMonster.currentHp - (hpLeft * ReturnEffectiveness(attack.attackElement, playerMonster.monster.type, false));
            //this will give the damage
            battlemanager.GiveDamage(hpLeft, false);
        }

        animator.Play(attack.animToPlayWhenAttackIsUsed.name);
    }

    //this will receive two types and give the effectiveness
    float ReturnEffectiveness(MonsterType typeOfAttackOrMonsterFromUser, MonsterType typeOfAttackOrMonsterFromEnemy, bool playerAttacked)
    {
        //if the player has attacked
        if(playerAttacked==true)
        {
            return 1;
        }
        //if the enemy is attacking
        else
        {
            return 1;
        }
        
    }

   
}
