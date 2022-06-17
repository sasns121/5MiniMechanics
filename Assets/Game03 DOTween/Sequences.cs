using UnityEngine;
using DG.Tweening;

public class Sequences : MonoBehaviour
{
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(3, 4).SetRelative());
        sequence.Insert(0, transform.DORotate(new Vector3(0, 0, 90), 4));
        sequence.Append(transform.DOMoveY(3, 4).SetRelative());
        sequence.Insert(4, transform.DORotate(new Vector3(0, 0, 180), 4));

        sequence.SetLoops(-1, LoopType.Yoyo);
    }

}
