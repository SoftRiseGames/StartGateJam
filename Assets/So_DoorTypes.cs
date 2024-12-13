using UnityEngine;
[CreateAssetMenu(fileName ="DoorType",menuName ="DoorType")]
public class So_DoorTypes : ScriptableObject
{
    public bool isCrackable;
    public DoorType GateType;
    public Sprite GateSprite;
}
public enum DoorType
{
    BallMultiplier,
    ScaleUpper,
    MomentumChanger,
    BulletPower,
    DoublerPower

} 