using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Camera_Aspect : MonoBehaviour {

    Camera cam;
    float aspect = 16.0f / 9.0f;

    private void Awake()
    {
        cam = Camera.main;

        AjustarResolucao();
    }
    void Start()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AjustarResolucao();
        }
    }

    void AjustarResolucao()
    {
        float scaleheight = ((float)Screen.width / (float)Screen.height) / aspect;
        // Se a altura da tela for menor que a tela alvo, ajustar altura
        if (scaleheight < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            cam.rect = rect;
        }

        else
        {
            // Se não ajustar largura
            float scalewidth = 1.0f / scaleheight;
            Rect rect = cam.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
