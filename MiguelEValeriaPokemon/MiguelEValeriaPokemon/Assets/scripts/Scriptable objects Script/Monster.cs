using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType {lava, shadow, earth, insect, ocean, ice, lightning, air, magic, hypnosis};
//make it possible to create objects of these in the menu,
//to access it just click right mouse on the folder, miguel things - > Monster
[CreateAssetMenu(fileName = "NewMonster", menuName = "MiguelThings/Monster")]
//its a scriptable object because its not associated with any object so its not a monobehaiour
public class Monster : ScriptableObject
{
    public int hp;
    //this defines how much defense the monster has agaist range attacks
    public int rangeDefense;
    //this defines how much defense the monster has agaist melee attacks
    public int meleeDefense;
    //this defines how much Damage the monster has when using a range attack
    public int rangeDamage;
    //this defines how much defense the monster has when using a melee attack
    public int meleeDamage;
    //this will be used to affect precision and critical hits
    public int accuracy;
    //who attacks first
    public int speed;
    [Space]
    //this enum has all types
    public MonsterType type;
    //this will have the story of the pokemon
    [TextArea(10, 20)]
    public string story;
    //this will store the name of the pokemon, i use new keyword, because scriptable object already has a defenition for name, and like ths i overwritt it
    public new string name;
    //this will store the monster sprite
    public Sprite image;

    //array of all the attacks available to the monster
    public AttacksArray[] allAttacks;

    //this will store all levels and when the level unlocks
    [System.Serializable]
    public struct AttacksArray
    {
        public Attacks attack;
        public int levelToUnlock;
    }
    

    
}
