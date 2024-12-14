using UnityEngine;
using System;

public class CharacterEvent : MonoBehaviour
{
    public static Action isCharacterDamage;
    void Start()
    {
        
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

    }
}
