using UnityEngine;
using System;
using System.Collections;


public class BallScript : MonoBehaviour
{
    [SerializeField] PhysicsMaterial2D physics;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 BallPose { get { return transform.position; } }
    int CollideCounter;
    [SerializeField] int bulletModeDeActivated;
    public static Action ColliderToSwitchAction;
    float startBounciness;
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
        //physics.bounciness = 0.85f;
        startBounciness = physics.bounciness;
    }
    private void OnEnable()
    {
        GateScript.isEnemScaleUp += BallUpScale;
        GateScript.isMomentumChange += MomentumChange;
        WallScript.ManaCount += CollideCounterVoid;
        WallScript.PowerCount += CollideCounterVoid;

    }
    private void OnDisable()
    {
        GateScript.isEnemScaleUp -= BallUpScale;
        GateScript.isMomentumChange -= MomentumChange;
        WallScript.ManaCount -= CollideCounterVoid;
        WallScript.PowerCount -= CollideCounterVoid;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollideCounter == bulletModeDeActivated)
            BulletModeDeActivate();
    }
    
    
    void BallUpScale() => gameObject.transform.localScale = new Vector2(1.25f, 1.25f);
    void MomentumChange() 
    {
        DeActivatedRb();
        ForceSystemManager.Instance.isDragForce = true;
    }
   
    void CollideCounterVoid() => CollideCounter = CollideCounter + 1;

    void BulletModeDeActivate()
    {
        ColliderToSwitchAction?.Invoke();
    }
 

}
