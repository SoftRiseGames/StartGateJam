using UnityEngine;
using DG.Tweening;

public class LavaFeedback : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.DOFade(0.2f, 2.2f).SetLoops(-1,LoopType.Yoyo);
        gameObject.transform.DOLocalMoveY(-8.5f,1.3f).SetLoops(-1, LoopType.Yoyo);
    }
}
