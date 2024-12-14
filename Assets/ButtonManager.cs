using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static Action isAmountDecrease;
    public static Action CharacterWindAction;
    public static Action CharacterShieldAction;
    public static Action InteractFalse;
    public static Action InteractTrue;

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
    public void SkillButtonInteractFalseSituation()
    {
        InteractFalse?.Invoke();
        Debug.Log("click");
    }
    public void SkillButtonInteractTrueSituation()
    {
        InteractTrue?.Invoke();
    }
    
}
