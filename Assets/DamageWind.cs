using UnityEngine;

public class DamageWind : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]WingType wingType;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if (wingType == WingType.CharacterWing)
            rb.linearVelocity = new Vector2(400 * Time.deltaTime, rb.linearVelocityY);
        else if(wingType == WingType.EnemyWing)
            rb.linearVelocity = new Vector2(-400 * Time.deltaTime, rb.linearVelocityY);

    }

  
}
public enum WingType
{
    CharacterWing,
    EnemyWing
}
