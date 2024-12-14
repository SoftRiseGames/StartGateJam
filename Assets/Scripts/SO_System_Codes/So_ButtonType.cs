using UnityEngine;
[CreateAssetMenu(fileName ="ButtonType",menuName ="ButtonType")]
public class So_ButtonType : ScriptableObject
{
    public ButtonType buttonType;
    public float MinManaCount;
}
public enum ButtonType
{
    Defence,
    Attack
}
