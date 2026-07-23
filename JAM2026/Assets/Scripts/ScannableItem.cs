using UnityEngine;
using UnityEngine.EventSystems;

public class ScannableItem : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public tillController game;
    [HideInInspector] public Canvas canvas;

    private RectTransform rect;
    private CanvasGroup group;
    private Vector2 startPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
        if (group == null) group = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData e)
    {
        startPos = rect.anchoredPosition;
        group.blocksRaycasts = false;
        transform.SetAsLastSibling();   // draw on top while dragging
    }

    public void OnDrag(PointerEventData e)
    {
        rect.anchoredPosition += e.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData e)
    {
        group.blocksRaycasts = true;

        if (game != null && game.IsOverScanner(e.position))
        {
            game.ItemScanned(this);
        }
        else
        {
            rect.anchoredPosition = startPos;   // snap back
        }
    }
}