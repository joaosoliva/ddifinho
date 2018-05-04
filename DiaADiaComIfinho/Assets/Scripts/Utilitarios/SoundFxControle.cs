using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxControle : MonoBehaviour
{
   private AudioClip currentFx;
   public void SetFx(AudioClip clip)
    {
        currentFx = clip;
        GetComponent<AudioSource>().PlayOneShot(currentFx);
    }
}
