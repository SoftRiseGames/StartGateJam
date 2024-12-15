using UnityEngine;
using System;
using Sirenix.OdinInspector;
using DG.Tweening;

public class WallScript : MonoBehaviour
{
    [SerializeField] CircleCollider2D collider;
    [SerializeField] private SpriteRenderer WallSpriteRenderer;
    [SerializeField] private SpriteRenderer FlashRenderer;
    public So_PowerAndManaWall WallType;
    public static Action PowerCount;
    public static Action ManaCount;
    public static Action ShieldCount;
    public static Action bulletMode;

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
            else if(WallType.wallType == global::WallType.ShieldBall)
            {
                ShieldCount?.Invoke();
            }
            DestroyFeedback();
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (WallType.wallType == global::WallType.ManaBall)
            {
                GameManager.Instance.ManaPointIncrease = WallType.ManaPowerAndShieldIncreaser;
                ManaCount?.Invoke();
            }

            else if (WallType.wallType == global::WallType.AmountBall)
            {
                GameManager.Instance.AttackPointIncrease = WallType.ManaPowerAndShieldIncreaser;
                PowerCount?.Invoke();
            }

            else if (WallType.wallType == global::WallType.ShieldBall)
            {
                GameManager.Instance.ShieldPointIncrease = WallType.ManaPowerAndShieldIncreaser;
                ShieldCount?.Invoke();
            }
            Destroy(gameObject);
        }
    }
    void ColliderToTriggerSwitch()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        bulletMode?.Invoke();
    }

    void TriggerToColliderSwitch()
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }


    //FEEDBACK

    Sequence myDeathSequence;
    private void DestroyFeedback()
    {
        myDeathSequence = DOTween.Sequence();
        myDeathSequence.Append(gameObject.transform.DOScale(0, 0.25f).SetEase(Ease.InBack));
        myDeathSequence.JoinCallback(() => HitFeedback());
        myDeathSequence.AppendCallback(() => Destroy(gameObject));
    }
    Sequence myHitSequence;
    private void HitFeedback()
    {
        myHitSequence = DOTween.Sequence();
        myHitSequence.JoinCallback(() => { FlashRenderer.color = Color.white; });
        myHitSequence.Join(FlashRenderer.DOColor(new Color(1, 1, 1, 0f), 0.25f));
    }

    private void OnDestroy()
    {
        DOTween.Kill(myDeathSequence);
        DOTween.Kill(myHitSequence);
    }
}
