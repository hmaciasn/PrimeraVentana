using UnityEngine;
using UnityEngine.EventSystems;

public class MoverObjeto : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject myDraggableSprite;

    private Vector3 startPosition;
    private float zDistanceToCamera;
    private Vector3 touchOffset;
    private Camera cam;

    public float moveSpeed = 20f; // ajusta velocidad si quieres suavizado

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (myDraggableSprite == null)
        {
            myDraggableSprite = gameObject;

            startPosition = transform.position;
            zDistanceToCamera = Mathf.Abs(startPosition.z - cam.transform.position.z);

            Vector3 screenPos = new Vector3(eventData.position.x, eventData.position.y, zDistanceToCamera);
            Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
            touchOffset = transform.position - worldPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (myDraggableSprite != gameObject) return;

        Vector3 screenPos = new Vector3(eventData.position.x, eventData.position.y, zDistanceToCamera);
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos) + touchOffset;

        // 🔹 Opción 1: movimiento inmediato (rápido y directo)
        transform.position = worldPos;

        // 🔹 Opción 2: movimiento suavizado (activa esta y comenta la de arriba si quieres)
        // transform.position = Vector3.Lerp(transform.position, worldPos, Time.deltaTime * moveSpeed);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (myDraggableSprite == gameObject)
        {
            myDraggableSprite = null;
        }

        touchOffset = Vector3.zero;
    }
}
