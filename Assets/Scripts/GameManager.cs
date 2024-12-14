using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _amountValue;
    private float _manaPoint;

    [HideInInspector] public float ShieldValue;
    [HideInInspector] public float AttackValue;
    public float AmountPointIncrease;
    public float ManaPointIncrease;

    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI AmountText;
    [SerializeField] TextMeshProUGUI ManaText;
    [SerializeField] TextMeshProUGUI ShieldText;

    public float AmountValue
    {
        get => _amountValue;
        set => _amountValue = Mathf.Max(0, value);
    }

    public float ManaPoint
    {
        get => _manaPoint;
        set => _manaPoint = Mathf.Max(0, value);
    }

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
        AmountText.text = "Amount: " + AmountValue.ToString();
        ManaText.text = "Mana: " + ManaPoint.ToString();
    }

    void AmpuntDoubler()
    {
        AmountValue *= 2;
        Debug.Log(AmountValue);
    }

    void AmountDoubler()
    {
        AmountValue += AmountPointIncrease;
        Debug.Log(AmountValue);
        Debug.Log("Power");
    }

    void ManaCounter()
    {
        ManaPoint += ManaPointIncrease;
        Debug.Log(ManaPointIncrease);
        Debug.Log(ManaPoint);
        Debug.Log("Mana");
    }
}
