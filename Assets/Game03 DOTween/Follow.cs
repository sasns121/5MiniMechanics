using UnityEngine;
using DG.Tweening;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Tweener _tween;
    private Vector3 _lastPosition;
    private void Start()
    {
        _tween = transform.DOMove(_target.position, 4).SetAutoKill(false);
        _lastPosition = _target.position;
    }
    private void Update()
    {
        if (_lastPosition != _target.position)
        {
            _tween.ChangeEndValue(_target.position, true).Restart();
            _lastPosition = _target.position;
        }
    }
}
