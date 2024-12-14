using UnityEngine;
using UnityEngine.UI;

public class ButtonDataControl : MonoBehaviour
{
    public So_ButtonType buttonOptions;
    public static ButtonDataControl instance;

    void Start()
    {
        if (instance == null)
            instance = this;
    }
    private void OnEnable()
    {
        ButtonManager.isAmountDecrease += AmountDecrease;
    }
    private void OnDisable()
    {
        ButtonManager.isAmountDecrease -= AmountDecrease;
    }

    void Update()
    {
        if (GameManager.Instance.ManaValueAmount >= buttonOptions.MinManaCount)
            gameObject.GetComponent<Button>().interactable = true;
        else
            gameObject.GetComponent<Button>().interactable = false;

    }
    void AmountDecrease()
    {
        if(GameManager.Instance.ManaValueAmount>0)
        GameManager.Instance.ManaValueAmount = GameManager.Instance.ManaValueAmount - buttonOptions.MinManaCount;
    }
   
}
