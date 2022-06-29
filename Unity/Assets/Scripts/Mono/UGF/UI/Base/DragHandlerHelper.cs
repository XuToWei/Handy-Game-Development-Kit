using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class DragHandlerHelper : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Action<PointerEventData> m_OnDragAction;
        private Action<PointerEventData> m_PointerDownAction;
        private Action<PointerEventData> m_PointerUpAction;

        public void OnDrag(PointerEventData eventData)
        {
            m_OnDragAction?.Invoke(eventData);
        }

        public void SetOnDragAction(Action<PointerEventData> onDragAction)
        {
            m_OnDragAction = onDragAction;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_PointerDownAction?.Invoke(eventData);
        }

        public void SetPointerDownAction(Action<PointerEventData> pointerDownAction)
        {
            m_PointerDownAction = pointerDownAction;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_PointerUpAction?.Invoke(eventData);
        }

        public void SetPointerUpAction(Action<PointerEventData> pointerUpAction)
        {
            m_PointerUpAction = pointerUpAction;
        }
    }
}
