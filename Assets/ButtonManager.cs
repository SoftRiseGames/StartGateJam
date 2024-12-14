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
    public void objectDoublerID()
    {
        SkillGateManager.ListNumber = 0;
    }
    public void ObjectUpscalerID()
    {
        SkillGateManager.ListNumber = 1;
    }
    public void MomentumChangerID()
    {
        SkillGateManager.ListNumber = 2;
    }
    public void bulletPowerID()
    {
        SkillGateManager.ListNumber = 3;
    }
    public void AmountDoublerID()
    {
        SkillGateManager.ListNumber = 4;
    }

    public void WingAttackDecreaseEvent()
    {

    }
    public void DefenceEvent()
    {

    }



}
