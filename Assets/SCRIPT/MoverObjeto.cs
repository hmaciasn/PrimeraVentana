using UnityEngine;
using UnityEngine.EventSystems;

public class MoverObjetoUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject myDraggableSprite;
    private Vector2 touchOffset;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (myDraggableSprite == null)
        {
            myDraggableSprite = gameObject;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localPoint);

            touchOffset = rectTransform.anchoredPosition - localPoint;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (myDraggableSprite != gameObject) return;

        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var localPoint))
        {
            rectTransform.anchoredPosition = localPoint + touchOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (myDraggableSprite == gameObject)
        {
            myDraggableSprite = null;
        }
        touchOffset = Vector2.zero;
    }
}
