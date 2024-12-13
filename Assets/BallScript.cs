using UnityEngine;
using System;
using System.Collections;
public class BallScript : MonoBehaviour
{
    [SerializeField] PhysicsMaterial2D physics;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 BallPose { get { return transform.position; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void DeActivatedRb()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    void Start()
    {
        physics.bounciness = 0.85f;
    }
    private void OnEnable()
    {
        DoorScript.isEnemScaleUp += BallUpScale;
        DoorScript.isEnemyBulletMode += BallBulletMode;
        DoorScript.isMomentumChange += MomentumChange;
        
    }
    private void OnDisable()
    {
        DoorScript.isEnemScaleUp -= BallUpScale;
        DoorScript.isEnemyBulletMode -= BallBulletMode;
        DoorScript.isMomentumChange -= MomentumChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "gate")
        {
            if (collision.transform.GetComponent<DoorScript>().GateType.GateType == DoorType.BallMultiplier)
            {
                Debug.Log("a");
            }
        }
    }
    */
    void BallUpScale() => gameObject.transform.localScale = new Vector2(1.25f, 1.25f);
    void MomentumChange() { }
    void BallBulletMode()
    {
        physics.bounciness = 0;
    }

}
