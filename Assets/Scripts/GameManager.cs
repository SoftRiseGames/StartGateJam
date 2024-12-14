using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _amountValue;
    private float _manaValue;
    private float _shieldValue;
    private float CharacterHealth;
    [HideInInspector] public float ShieldValue;
    [HideInInspector] public float AttackValue;
    public float AmountPointIncrease;
    public float ManaPointIncrease;
    public float ShieldPointIncrease;
    public bool canDrag = true;

    public static GameManager Instance;


    [SerializeField] TextMeshProUGUI AmountText;
    [SerializeField] TextMeshProUGUI ManaText;
    [SerializeField] TextMeshProUGUI ShieldText;

    public float EnemyDamage;
    public float StandartValueAmount
    {
        get => _amountValue;
        set => _amountValue = Mathf.Max(0, value);
    }

    public float ManaValueAmount
    {
        get => _manaValue;
        set => _manaValue = Mathf.Max(0, value);
    }
    public float ShieldValueAmount
    {
        get => _shieldValue;
        set => _shieldValue = Mathf.Max(0, value);
    }

    private void OnEnable()
    {
        GateScript.isPowerDoubler += AmpuntDoubler;
        WallScript.ManaCount += ManaCounter;
        WallScript.ShieldCount += ShieldCounter;
        WallScript.PowerCount += AmountDoubler;
        CharacterEvent.isCharacterDamage += ShieldAndHealthDecreraser;
    }

    private void OnDisable()
    {
        GateScript.isPowerDoubler -= AmpuntDoubler;
        WallScript.ManaCount -= ManaCounter;
        WallScript.PowerCount -= AmountDoubler;
        WallScript.ShieldCount -= ShieldCounter;
        CharacterEvent.isCharacterDamage -= ShieldAndHealthDecreraser;
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        AmountText.text = "Amount: " + StandartValueAmount.ToString();
        ManaText.text = "Mana: " + ManaValueAmount.ToString();
    }

    void AmpuntDoubler()
    {
        StandartValueAmount *= 2;
        Debug.Log(StandartValueAmount);
    }

    void AmountDoubler()
    {
        StandartValueAmount += AmountPointIncrease;
        Debug.Log(StandartValueAmount);
        Debug.Log("Power");
    }

    void ManaCounter()
    {
        ManaValueAmount += ManaPointIncrease;
        Debug.Log(ManaPointIncrease);
        Debug.Log(ManaValueAmount);
        Debug.Log("Mana");
    }

    void ShieldCounter()
    {
        ShieldValue += ShieldPointIncrease;
        Debug.Log(ManaPointIncrease);
        Debug.Log(ManaValueAmount);
        Debug.Log("Shield");
    }

    void ShieldAndHealthDecreraser()
    {
        ShieldValue = ShieldValue - EnemyDamage;
        if (ShieldValue <= 0)
        {
            CharacterHealth = CharacterHealth - Mathf.Abs(ShieldValue);
        }
    
    }
}
