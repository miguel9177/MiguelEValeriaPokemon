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
    }

    public TrainerMonsters[] trainerMonsters;

}
