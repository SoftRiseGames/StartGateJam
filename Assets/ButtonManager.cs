using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static Action isAmountDecrease;
    public static Action CharacterWindAction;
    public static Action CharacterShieldAction;
    public static Action InteractFalse;

  public void CharacterButtonEvent()
    {
        isAmountDecrease?.Invoke();
    }
    public void CharacterWindEvent()
    {
        CharacterWindAction?.Invoke();
    }
    public void CharacterShieldEvent()
    {
        CharacterShieldAction?.Invoke();
    }
    public void SkillButtonInteractSituation()
    {
        InteractFalse?.Invoke();
        Debug.Log("click");
    }
}
