using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrainerBattleItemsAndMonsters))]
public class BattleInitializer : MonoBehaviour
{
    //gets the battle manager to be able to initialize the battle
    [SerializeField]
    BattleManager battleManager;

   
    //this function will start the battle, it sends the information of this trainer to the battleManager
    public void StartBattle()
    {
        if(this.gameObject.GetComponent<TrainerBattleItemsAndMonsters>())
        {
            battleManager.StartBattle(this.gameObject.GetComponent<TrainerBattleItemsAndMonsters>());
        }
        else
        { Debug.LogError("ESTE OBJETO N TEM UM TRAINER BATTLE ITEMS SCRIPT"); }
    }
}
