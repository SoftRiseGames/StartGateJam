using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public bool canDrag = true;
    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI AttackText;
    [SerializeField] TextMeshProUGUI ManaText;
    [SerializeField] TextMeshProUGUI ShieldText;

    [SerializeField] TextMeshProUGUI EarnedShield;
    [SerializeField] TextMeshProUGUI EarnedEnemyShieldText;
    public float AttackValueAmount;
    public float ManaValueAmount;
    public float ShieldValueAmount;


    public float AttackPointIncrease;
    public float ManaPointIncrease;
    public float ShieldPointIncrease;

    [SerializeField] Entity CharacterEntity;
    [SerializeField] Entity EnemyEntity;

    bool fire;


    [SerializeField] List<Button> AllButtons;


    //Feel
    [SerializeField] Transform CameraPosition;

    public Sprite ObjectDoublerSprite;
    public Sprite ObjectUpscaleSprite;
    public Sprite MomentumChangerSprite;
    public Sprite BulletSprite;

    Sequence attackSequence;
    
    private void AttackToEnemy()
    {
        if (ManaValueAmount <= 0) return;

        ManaValueAmount--;
        attackSequence = DOTween.Sequence();
        attackSequence.AppendCallback(() =>
        {
            CharacterEntity.Attack(AttackValueAmount, EnemyEntity, 1f);
        });
        attackSequence.AppendInterval(0.2f);
        attackSequence.AppendCallback(() =>
        {
            GameObject inst = Instantiate(CharacterEntity.attackOBJ, CharacterEntity.transform.position, Quaternion.identity);
            inst.transform.DOMoveX(EnemyEntity.transform.position.x, 1f).OnComplete(() =>Destroy(inst));
            /*
            attackSequence.Append(inst.transform.DOMove(EnemyEntity.transform.position, 1f));
            attackSequence.AppendCallback(() =>
            {
                Destroy(inst.gameObject);
            });
            */
        });
    }
    
    private void Shield()
    {
        if (ManaValueAmount <= 0) return;
        ManaValueAmount--;

        CharacterEntity.Shield(ShieldValueAmount);
    }
    private void EnemyToChar()
    {
        if(EnemyEntity.schema[EnemyEntity.schemaIndex] == 1)
        {
            attackSequence = DOTween.Sequence();
            attackSequence.AppendCallback(() =>
            {
                EnemyEntity.Attack(EnemyEntity.AttackDamage, CharacterEntity, 1f);
            });
            /*
            attackSequence.AppendInterval(0.2f);
            attackSequence.AppendCallback(() =>
            {
                GameObject inst = Instantiate(EnemyEntity.attackOBJ, EnemyEntity.transform.position, Quaternion.identity);
                attackSequence.Append(inst.transform.DOMove(CharacterEntity.transform.position, 1f));

            });
            */
            GameObject splash =Instantiate(EnemyEntity.attackOBJ);
            splash.transform.DOMoveX(CharacterEntity.transform.position.x + .5f, 1f).OnComplete(() => {  Destroy(splash); StartTurn(); });
        }


        else
        {
            EnemyEntity.Shield(EnemyEntity.ShieldIncrease);
            StartTurn();
           
        }
        EnemyEntity.schemaIndex++;
        if (EnemyEntity.schema.Count - 1 == EnemyEntity.schemaIndex)
        {
            EnemyEntity.schemaIndex = 0;
        }
        StartCoroutine(waitRocket());
    }
    IEnumerator waitRocket()
    {

        yield return new WaitForSeconds(0.20f);
        fire = true;

    }
    private void StartTurn()
    {
        canDrag = true;
        AllButtonsHudUpdate(true);
    }
    private void EndTurn()
    {
        canDrag = false;
        AllButtonsHudUpdate(false);
        EnemyToChar();

        ShieldValueAmount = 0;
        AttackValueAmount = 0;

    }


    private void AllButtonsHudUpdate(bool isInteractable)
    {
        foreach(Button but in AllButtons)
        {
            but.interactable = isInteractable;
        }
    }


    private void Update()
    {
        AttackText.text = AttackValueAmount.ToString();
        ManaText.text = ManaValueAmount.ToString();
        ShieldText.text = ShieldValueAmount.ToString();
        EarnedShield.text = CharacterEntity.ShieldFloat.ToString();
        EarnedEnemyShieldText.text = EnemyEntity.ShieldFloat.ToString();
    }
    void AmpuntDoubler()
    {
        AttackValueAmount *= 2;
        Debug.Log(AttackValueAmount);
    }

    void AmountDoubler()
    {
        AttackValueAmount += AttackPointIncrease;
    }

    void ManaCounter()
    {
        ManaValueAmount += ManaPointIncrease;
    }

    void ShieldCounter()
    {
        ShieldValueAmount += ShieldPointIncrease;
    }
    private void OnEnable()
    {
        ButtonManager.Atacked += AttackToEnemy;
        ButtonManager.Shielded += Shield;
        ButtonManager.EndTurn += EndTurn;

        GateScript.isPowerDoubler += AmpuntDoubler;
        WallScript.ManaCount += ManaCounter;
        WallScript.ShieldCount += ShieldCounter;
        WallScript.PowerCount += AmountDoubler;
    }

    private void OnDisable()
    {
        ButtonManager.Atacked -= AttackToEnemy;
        ButtonManager.Shielded -= Shield;
        ButtonManager.EndTurn -= EndTurn;


        GateScript.isPowerDoubler -= AmpuntDoubler;
        WallScript.ManaCount -= ManaCounter;
        WallScript.PowerCount -= AmountDoubler;
        WallScript.ShieldCount -= ShieldCounter;
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }


}