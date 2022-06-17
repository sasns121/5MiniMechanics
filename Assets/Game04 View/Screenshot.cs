using System;
using UnityEngine;

[Serializable]
public class Screenshot 
{
    private Sprite _sprite;
    private DateTime _dateTime;

    public Screenshot(Sprite sprite, DateTime dateTime)
    {
        _sprite = sprite;
        _dateTime = dateTime;
    }

    public Sprite Sprite => _sprite;
    public DateTime DateTime => _dateTime;
}
