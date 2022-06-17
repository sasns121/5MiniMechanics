using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game01
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Color _targetColor;

        public void ChangeColor()
        {
            _renderer.color = _targetColor;
        }
    }
}
