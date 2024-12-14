using UnityEngine;


[CreateAssetMenu(fileName ="Mana And Power Ball", menuName ="Mana And Power Ball")]
public class So_PowerAndManaWall : ScriptableObject
{
    public Sprite WallSkin;
    public WallType wallType;
    public float ManaOrPowerIncreaser;
}
public enum WallType
{
    ManaBall,
    AmountBall
}