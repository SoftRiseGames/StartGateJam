using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] GameObject Wind;
    [SerializeField] Transform SpawnPoint;
    [HideInInspector]public float Shield;
    private void OnEnable()
    {
        ButtonManager.CharacterWindAction += WindCharacter;
        ButtonManager.CharacterShieldAction += ShieldCharacter;
    }
    private void OnDisable()
    {
        ButtonManager.CharacterWindAction -= WindCharacter;
        ButtonManager.CharacterShieldAction -= ShieldCharacter;
    }
    public void WindCharacter()
    { 
        Instantiate(Wind, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        GameManager.Instance.AttackValue = GameManager.Instance.AttackValue + ButtonDataControl.instance.buttonOptions.AttackValue;
    }
    public void ShieldCharacter()
    {
        GameManager.Instance.ShieldValue = GameManager.Instance.ShieldValue + ButtonDataControl.instance.buttonOptions.DefenceShieldValue;
    }

}
