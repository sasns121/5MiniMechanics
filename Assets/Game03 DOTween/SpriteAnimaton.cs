using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimaton : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _spriteRenderer.DOColor(Color.red, 1).SetLoops(-1,LoopType.Yoyo);
        _spriteRenderer.DOFade(0, 2).SetLoops(-1, LoopType.Yoyo);

    }

}
