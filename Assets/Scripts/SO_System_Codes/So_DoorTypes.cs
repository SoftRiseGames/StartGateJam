using UnityEngine;
[CreateAssetMenu(fileName ="DoorType",menuName ="DoorType")]
public class So_DoorTypes : ScriptableObject
{
    public DoorType GateType;
    public float Price;
    public Sprite GateSprite;
}
public enum DoorType
{
    BallMultiplier,
    ScaleUpper,
    MomentumChanger,
    BulletPower,
    DoublerAmount

} 