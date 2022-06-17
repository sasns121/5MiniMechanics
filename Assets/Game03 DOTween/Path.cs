using UnityEngine;
using DG.Tweening;

public class Path : MonoBehaviour
{
    [SerializeField] private Vector3[] _wayPoints;
    void Start()
    {
        Tween tween = transform.DOPath(_wayPoints, 6, PathType.CatmullRom).SetOptions(true).SetLookAt(0.50f,Vector3.left);
        tween.SetEase(Ease.Linear).SetLoops(-1);

    }

}
