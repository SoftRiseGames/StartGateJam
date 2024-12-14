using UnityEngine;

public class GameManager : MonoBehaviour
{
    float AmountCoin;
    public float ManaPoint;
    public float AmountPointIncrease;
    public float ManaPointIncrease;

    public static GameManager Instance;
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


    void AmpuntDoubler() 
    {
        AmountCoin = AmountCoin * 2;
        Debug.Log(AmountCoin);

    } 
    void AmountDoubler() 
    {
        AmountCoin = AmountCoin + AmountPointIncrease;
        Debug.Log(AmountCoin);
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
