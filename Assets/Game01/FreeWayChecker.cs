using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float _rayCastDistance;
    [SerializeField] private float _speed;
    private readonly RaycastHit2D[] results = new RaycastHit2D[1];



    private void FixedUpdate()
    {
        var collisionCount= _rigidbody2D.Cast(transform.right, _filter, results, _rayCastDistance);
        if (collisionCount == 0) 
            _rigidbody2D.velocity = transform.right * _speed;
    }
}
