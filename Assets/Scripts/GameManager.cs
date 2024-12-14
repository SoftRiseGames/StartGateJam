using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _amountValue;
    private float _manaPoint;

    private float CharacterHealth;
    [HideInInspector] public float ShieldValue;
    [HideInInspector] public float AttackValue;
    public float AmountPointIncrease;
    public float ManaPointIncrease;
    public bool canDrag = true;

    public static GameManager Instance;


    [SerializeField] TextMeshProUGUI AmountText;
    [SerializeField] TextMeshProUGUI ManaText;
    [SerializeField] TextMeshProUGUI ShieldText;

    public float EnemyDamage;
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
        CharacterEvent.isCharacterDamage += ShieldAndHealthDecreraser;
    }

    private void OnDisable()
    {
        GateScript.isPowerDoubler -= AmpuntDoubler;
        WallScript.ManaCount -= ManaCounter;
        WallScript.PowerCount -= AmountDoubler;
        CharacterEvent.isCharacterDamage -= ShieldAndHealthDecreraser;
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

    void ShieldAndHealthDecreraser()
    {
        ShieldValue = ShieldValue - EnemyDamage;
        if (ShieldValue <= 0)
        {
            CharacterHealth = CharacterHealth - Mathf.Abs(ShieldValue);
        }
    
    }
}
