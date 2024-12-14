using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static Action isAmountDecrease;
    public static Action CharacterWindAction;
    public static Action CharacterShieldAction;
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
}
