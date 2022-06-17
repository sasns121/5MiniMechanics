using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndTarget : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached; // ��� ��� ���� ���������, �� ������� C# ������� ����������� ��� ���� 
    public bool IsReached { get; private set; }
    public event UnityAction Reached                     //������ ����������� �� _reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached) return;
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsReached = true;
            _reached?.Invoke();
        }
    }
}
