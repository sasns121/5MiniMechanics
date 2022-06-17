using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using Assets.Game04_View.Extensions;

public class ScreenshotView : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    private Transform _dragingParent;
    private Transform _previousParent;
    private RectTransform _rectTransform;
    private Vector2 _startPos;
    private Vector2 _startPosMouse;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    public void Init(Transform dragingCanvas)
    {
        _dragingParent = dragingCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousParent = transform.parent;
        transform.SetParent(_dragingParent);
        _startPosMouse = new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height);
        _startPos = _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height);
        _rectTransform.anchoredPosition = _startPos + (mousePos - _startPosMouse);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        var container = EventSystem.current.GetFirstComponentUnderPointer<DropContainer>(eventData);
        if (container!=null)
            transform.SetParent(container.Container);
        else
            transform.SetParent(_previousParent);
        
    }

    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Sprite;
        _text.text = screenshot.DateTime.ToString();
    }

   
}
