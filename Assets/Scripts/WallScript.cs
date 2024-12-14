using UnityEngine;
using System;
using Sirenix.OdinInspector;


public class WallScript : MonoBehaviour
{
    [SerializeField] CircleCollider2D collider;
    [SerializeField] private SpriteRenderer WallSpriteRenderer;
    public So_PowerAndManaWall WallType;
    public static Action PowerCount;
    public static Action ManaCount;

    [Button("Initialize Bubble")]
    public void InitBubble(So_PowerAndManaWall bubble)
    {
        WallType = bubble;
        WallSpriteRenderer.sprite = WallType.WallSkin;
    }

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
    }
    private void OnEnable()
    {
        GateScript.isBulletMode += ColliderToTriggerSwitch;
        BallScript.ColliderToSwitchAction += TriggerToColliderSwitch;
    }
    private void OnDisable()
    {
        GateScript.isBulletMode -= ColliderToTriggerSwitch;
        BallScript.ColliderToSwitchAction -= TriggerToColliderSwitch;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (WallType.wallType == global::WallType.ManaBall)
            {
                ManaCount?.Invoke();
            }
                
            else if (WallType.wallType == global::WallType.AmountBall)
            {
                PowerCount?.Invoke();
            }
            Destroy(gameObject);
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (WallType.wallType == global::WallType.ManaBall)
            {
                GameManager.Instance.ManaPointIncrease = WallType.ManaOrPowerIncreaser;
                ManaCount?.Invoke();
            }

            else if (WallType.wallType == global::WallType.AmountBall)
            {
                GameManager.Instance.AmountPointIncrease = WallType.ManaOrPowerIncreaser;
                PowerCount?.Invoke();
            }
            Destroy(gameObject);
        }
    }
    void ColliderToTriggerSwitch()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void TriggerToColliderSwitch()
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
