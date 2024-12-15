using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{

    public static Action Atacked;
    public static Action Shielded;
    public static Action EndTurn;
    public static Action InteractFalse;
    public static Action InteractTrue;

    public void AttackButton()
    {
        Atacked?.Invoke();
    }
    public void ShieldButton()
    {
        Shielded?.Invoke();
    }

    public void EndTurnButton()
    {
        EndTurn?.Invoke();
    }

    public void SkillButtonInteractFalseSituation()
    {
        InteractFalse?.Invoke();
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
