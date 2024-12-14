using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillGateManager : MonoBehaviour
{
    public List<GameObject> SkillButtons;

    private void OnEnable()
    {
        ButtonManager.InteractFalse += FalseInteract;
    }
    private void OnDisable()
    {
        ButtonManager.InteractFalse -= FalseInteract;
    }
    void FalseInteract()
    {
        foreach (GameObject skillbutton in SkillButtons)
        {
            skillbutton.GetComponent<Button>().interactable = false;
        }
    }
    void TrueInteract()
    {
        foreach (GameObject skillbutton in SkillButtons)
        {
            skillbutton.GetComponent<Button>().interactable = true;
        }
    }

}
