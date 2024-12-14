using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float EnemyHealth;
    public float EnemyIncreaser;
    public bool canDrag = true;
    public float EnemyShield;
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
        CharacterAndEnemyEvent.isCharacterDamage += CharacterShieldAndHealthDecreraser;
        CharacterAndEnemyEvent.isEnemyDamage += EnemyShieldAndHealthDecreaser;
    }

    private void OnDisable()
    {
        GateScript.isPowerDoubler -= AmpuntDoubler;
        WallScript.ManaCount -= ManaCounter;
        WallScript.PowerCount -= AmountDoubler;
        WallScript.ShieldCount -= ShieldCounter;
        CharacterAndEnemyEvent.isCharacterDamage -= CharacterShieldAndHealthDecreraser;
        CharacterAndEnemyEvent.isEnemyDamage -= EnemyShieldAndHealthDecreaser;
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
        ShieldText.text = "Shield: " + ShieldValueAmount.ToString();
    }
    void GameOver()
    {
        if (EnemyHealth <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (CharacterHealth <= 0)
            Debug.Log("Game Over");
            
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
        Debug.Log("Shield");
    }
    void EnemyShieldAndHealthDecreaser()
    {
        EnemyShield = EnemyShield - StandartValueAmount;
        if (ShieldValue <= 0)
        {
            EnemyHealth = EnemyHealth - Mathf.Abs(EnemyShield);
        }
    }
    void CharacterShieldAndHealthDecreraser()
    {
        ShieldValue = ShieldValue - EnemyDamage;
        if (ShieldValue <= 0)
        {
            CharacterHealth = CharacterHealth - Mathf.Abs(ShieldValue);
        }
    
    }
}
