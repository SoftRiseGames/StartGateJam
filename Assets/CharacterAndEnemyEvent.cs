using UnityEngine;
using System;

public class CharacterAndEnemyEvent : MonoBehaviour
{
    public So_EnemyType enemy;
    public static Action isCharacterDamage;
    public static Action isEnemyDamage;
    void Start()
    {
        if (gameObject.tag == "Enemy")
            GameManager.Instance.EnemyHealth = enemy.EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DamageWindEnemy")
        {
            GameManager.Instance.EnemyDamage = collision.transform.GetComponent<DamageWind>().EnemyDamage;
            isCharacterDamage?.Invoke();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "DamageWindCharacter")
        {
            GameManager.Instance.EnemyIncreaser = enemy.EnemyDecreaser;
            isEnemyDamage?.Invoke();
        }

    }

    void EnemyShield()
    {
        if(gameObject.tag == "Enemy")
        {
            GameManager.Instance.EnemyShield = enemy.ShieldAmount;
        }
    }
}
