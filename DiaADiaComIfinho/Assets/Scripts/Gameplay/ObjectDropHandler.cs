using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDropHandler : MonoBehaviour, IDropHandler {

    [SerializeField]
    Minigame3 minigame3;

    [SerializeField]
    TutorialBasic tutorialBasic;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Vector3 inPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.GetComponent<RectTransform>(),eventData.position,eventData.pressEventCamera,out inPosition))
        {
            if (minigame3 != null)
            {
                minigame3.ConfirmarSelecao();
            }
            else
            {
                tutorialBasic.Selecionar(0);
            }
        }
    }
}
