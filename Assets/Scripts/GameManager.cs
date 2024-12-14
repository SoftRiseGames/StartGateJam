using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float AmountValue;
    public float ManaPoint;
    public float AmountPointIncrease;
    public float ManaPointIncrease;

    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI AmountText;
    [SerializeField] TextMeshProUGUI ManaText;
    private void OnEnable()
    {
        GateScript.isPowerDoubler += AmpuntDoubler;
        WallScript.ManaCount += ManaCounter;
        WallScript.PowerCount += AmountDoubler;

       
    }
    private void OnDisable()
    {
        GateScript.isPowerDoubler -= AmpuntDoubler;
        WallScript.ManaCount -= ManaCounter;
        WallScript.PowerCount -= AmountDoubler;
    }
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Update()
    {
        AmountText.text ="Amount: " +AmountValue.ToString();
        ManaText.text ="Mana: "+ ManaPoint.ToString();
    }

    void AmpuntDoubler() 
    {
        AmountValue = AmountValue * 2;
        Debug.Log(AmountValue);

    } 
    void AmountDoubler() 
    {
        AmountValue = AmountValue + AmountPointIncrease;
        Debug.Log(AmountValue);
        Debug.Log("Power");
    }

    void ManaCounter() 
    {
        ManaPoint = ManaPoint + ManaPointIncrease;
        Debug.Log(ManaPointIncrease);
        Debug.Log(ManaPoint);
        Debug.Log("Mana");
    } 
}
