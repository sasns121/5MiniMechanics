using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockJump : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Rigidbody2D _rigidBody2D;
    [SerializeField] float _jumpForse;
    public void OnPointerClick(PointerEventData eventData)
    {
        _rigidBody2D.AddForce(Vector2.up* _jumpForse, ForceMode2D.Impulse);
    }
}
