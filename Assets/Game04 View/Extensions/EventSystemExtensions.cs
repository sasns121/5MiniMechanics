using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Assets.Game04_View.Extensions
{
    static class EventSystemExtensions
    {
        public static T GetFirstComponentUnderPointer<T>(this EventSystem system, PointerEventData pointer) where T : class
        {
            var result = new List<RaycastResult>();
            system.RaycastAll(pointer, result);

            foreach (var item in result)
                if (item.gameObject.TryGetComponent<T>(out T component))
                    return component;
            return null;
            
        }
    }
}
