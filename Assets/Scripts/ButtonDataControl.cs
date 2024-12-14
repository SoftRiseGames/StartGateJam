using UnityEngine;
using UnityEngine.UI;

public class ButtonDataControl : MonoBehaviour
{
    [SerializeField] So_ButtonType buttonOptions;
    void Start()
    {
        Debug.Log(buttonOptions.MinManaCount);
    }

    
    void Update()
    {
        if (GameManager.Instance.ManaPoint >= buttonOptions.MinManaCount)
            gameObject.GetComponent<Button>().interactable = true;
        else
            gameObject.GetComponent<Button>().interactable = false;

    }
}
