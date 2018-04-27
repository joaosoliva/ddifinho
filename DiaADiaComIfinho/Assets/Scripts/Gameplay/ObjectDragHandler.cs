using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

    [SerializeField]
    Minigame3 minigame3;
    [SerializeField]
    int id;

    Vector3 originalPosition;

    Transform parent;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        parent = transform.parent;
        originalPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        minigame3.Selecionar(id);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out globalMousePos);
        transform.GetComponent<RectTransform>().position = globalMousePos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(parent);
        transform.position = originalPosition;
    }
}
