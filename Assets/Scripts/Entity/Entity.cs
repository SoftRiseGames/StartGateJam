using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

public class Entity : MonoBehaviour, IEntity
{
    public GameObject attackOBJ;
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI ShieldText;
    [SerializeField] Animator anim;
    public float HealthFloat;
    public float MaxHealthFloat;
    public float ShieldFloat;
    public float ShieldIncrease;
    public float AttackDamage;
    public List<int> schema;
    public int schemaIndex = 0;


    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Idle");
        UpdateHUD();
    }
   
    public bool Attack(float attackPower,Entity entity,float duration)
    {
        anim.Play("Attack");
        DOVirtual.DelayedCall(duration, () =>
         {
             Debug.Log("Attack");
             entity.TakeDamage(attackPower);
             
             if (entity.HealthFloat <= 0)
             {
                 entity.Death();
             }
         });

        return false;

    }
    
    
    public void Shield(float shieldPower)
    {
        ShieldFloat += shieldPower;
    }
    

    public void TakeDamage(float damage)
    {
       
        ShieldFloat = ShieldFloat - damage;
        
        if(ShieldFloat<= 0)
        {
            HealthFloat -= Mathf.Abs(ShieldFloat);
            ShieldFloat = 0;
        }
       
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        HealthText.text = $"{HealthFloat}/{MaxHealthFloat}";
        ShieldText.text = ShieldFloat.ToString();

    }

    public void Death()
    {

    }
}
