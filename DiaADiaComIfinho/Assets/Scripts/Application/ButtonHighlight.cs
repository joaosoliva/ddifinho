using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip soundHighlight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.instance.RandomizeSfx(soundHighlight, soundHighlight);
    }
}
