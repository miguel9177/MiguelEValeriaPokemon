using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will get all of type attacks
public enum TypeOfAttack { damage, stats, healing, damageWithCondition};
public enum AttackDamageType { rangeType, meleeType};
//to access it just click right mouse on the folder, miguel things - > Monster
[CreateAssetMenu(fileName = "NewAttack", menuName = "MiguelThings/Attacks")]
public class Attacks : ScriptableObject
{
    //the damage and the condition damage are values that are going to be accessed by a function of other script, and this integers, will be used to add heale, give damage with recoil etc.
    public int damage;
    public int conditionDamageToSend;

    [TextArea(10, 20)]
    public string attackDescription;
    //this will store the name of the attack, i use new keyword, because scriptable object already has a defenition for name, and like ths i overwritt it
    public new string name;

    //this 2 will create 2 dropdowns (enums) with the options of type of attack and attack damage type
    public TypeOfAttack typeOfAttack;
    public AttackDamageType damageType;
    //this will create a dropdown with the element of the attack (fire, ocean etc)
    public MonsterType attackElement;
}
