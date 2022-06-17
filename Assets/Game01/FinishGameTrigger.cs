using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameTrigger : MonoBehaviour
{
    [SerializeField] private EndTarget[] _targets;

    private void OnEnable()
    {
        //_targets = GameObject.FindObjectsOfType<EndTarget>(); //��� �������
        _targets = gameObject.GetComponentsInChildren<EndTarget>(); //������ ��������. �� ������� ������� �����������. ����� ����. 

        foreach (var target in _targets)          // ����� ������ ���������� �� ��������� ����� ������� (����� ����� ��� � onClick) ��� ������ �� �������� 
            target.Reached += OnEndPointReached;
        
    }
    private void OnDisable()
    {
        foreach (var target in _targets)          // � ��� �����������  
            target.Reached -= OnEndPointReached;
    }
    private void OnEndPointReached() {
        foreach (var target in _targets)          // ��������� ��������� ��� �� ������� ������� 
            if (target.IsReached == false) {
                return;
            }
        Debug.Log("Finish");
    }
}
