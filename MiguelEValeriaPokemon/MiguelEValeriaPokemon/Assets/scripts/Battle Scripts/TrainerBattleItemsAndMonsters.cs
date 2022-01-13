using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerBattleItemsAndMonsters : MonoBehaviour
{
    [System.Serializable]
    public struct TrainerMonsters
    {
        //this will store the monster of the trainer
        public Monster monster;
        //this will store the monster level
        public int level;
        //this will store the monsters attacks
        public Attacks[] attacks;

        //this will store all of the stats to increase
        public int hpToIncrease;
        public int acuracyToIncrease;
        public int speedToIncrease;
        public int rangeDefenseToIncrease;
        public int meleeDefenseToIncrease;
        public int rangeDamageToIncrease;
        public int meleeDamageToIncrease;

        public int ReturnMonsterHp() { return hpToIncrease + monster.hp; }
        public int ReturnMonsterAcuracy() { return acuracyToIncrease + monster.accuracy; }
        public int ReturnMonsterSpeed() { return speedToIncrease + monster.speed; }
        public int ReturnMonsterRangeDefense() { return rangeDefenseToIncrease + monster.rangeDefense; }
        public int ReturnMonsterMeleeDefense() { return meleeDefenseToIncrease + monster.meleeDefense; }
        public int ReturnMonsterRangeDamage() { return rangeDamageToIncrease + monster.rangeDamage; }
        public int ReturnMonsterMeleeDamage() { return meleeDamageToIncrease + monster.meleeDamage; }
    }

    public TrainerMonsters[] trainerMonsters;
    
    
    

}
