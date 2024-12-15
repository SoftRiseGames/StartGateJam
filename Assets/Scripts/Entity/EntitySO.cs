using UnityEngine;


[CreateAssetMenu(fileName = "EntitySO", menuName = "Create New Entity")]
public class EntitySO : ScriptableObject
{
    public Sprite EntitySprite;
    public AnimatorOverrideController EntityAnimator;
    public GameObject EntityAttackOBJ;
}
