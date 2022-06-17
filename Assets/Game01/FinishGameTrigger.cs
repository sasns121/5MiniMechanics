using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameTrigger : MonoBehaviour
{
    [SerializeField] private EndTarget[] _targets;

    private void OnEnable()
    {
        //_targets = GameObject.FindObjectsOfType<EndTarget>(); //все объекты
        _targets = gameObject.GetComponentsInChildren<EndTarget>(); //только дочерние. Не наушает принцип зависимости. Более явно. 

        foreach (var target in _targets)          // когда объект включается мы добавляем новое событие (читай ивент как в onClick) для кажого из таргетов 
            target.Reached += OnEndPointReached;
        
    }
    private void OnDisable()
    {
        foreach (var target in _targets)          // а тут отключается  
            target.Reached -= OnEndPointReached;
    }
    private void OnEndPointReached() {
        foreach (var target in _targets)          // перебором проверяем все ли таргеты найдены 
            if (target.IsReached == false) {
                return;
            }
        Debug.Log("Finish");
    }
}
