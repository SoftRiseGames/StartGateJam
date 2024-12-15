using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="EnemyType",menuName ="EnemyType")]
public class So_EnemyType : ScriptableObject
{
    public float EnemyHealth;
    public float EnemyDecreaser;
    public float Price;
    public Sprite EnemySkin;
    public float ShieldAmount;
    public List<string> Attackpattern;

}
