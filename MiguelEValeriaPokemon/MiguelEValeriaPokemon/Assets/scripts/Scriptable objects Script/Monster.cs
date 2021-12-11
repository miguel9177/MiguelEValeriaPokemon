using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType {lava, shadow, earth, insect, water, ice, lightning, air, magic, hypnosis };
//make it possible to create objects of these in the menu,
//to access it just click right mouse on the folder, miguel things - > Monster
[CreateAssetMenu(fileName = "NewMonster", menuName = "MiguelThings/Monster")]
//its a scriptable object because its not associated with any object so its not a monobehaiour
public class Monster : ScriptableObject
{
    public int hp;
    public int damage;
    //this will be used to affect precision and critical hits
    public int accuracy;
    //who attacks first
    public int speed;
    //this enum has all types
    public MonsterType type;
    //this will have the story of the pokemon
    public string story;
    //this will store the name of the pokemon, i use new keyword, because scriptable object already has a defenition for name, and like ths i overwritt it
    public new string name;
    //this will store the monster sprite
    public Sprite image;
}
