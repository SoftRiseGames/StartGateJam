using UnityEngine;
[CreateAssetMenu(fileName ="ButtonType",menuName ="ButtonType")]
public class So_ButtonType : ScriptableObject
{
    public ButtonType buttonType;
    public float MinManaCount;
    public float DefenceShieldValue;
    public float AttackValue;
}
public enum ButtonType
{
    Defence,
    Attack
}
