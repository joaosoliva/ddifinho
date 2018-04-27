using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDropHandler : MonoBehaviour, IDropHandler {

    [SerializeField]
    Minigame3 minigame3;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Vector3 inPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.GetComponent<RectTransform>(),eventData.position,eventData.pressEventCamera,out inPosition))
        {
            minigame3.ConfirmarSelecao();
        }
    }
}
