using UnityEngine;

public class DamageWind : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.linearVelocity = new Vector2(400 * Time.deltaTime, rb.linearVelocityY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
