using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTo : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(new Vector3(0, 0), 2).SetLoops(-1,LoopType.Yoyo);
        //.Dalay(time)- задержка
        //.From() -из указанной точки там где стоишь
    }
}
