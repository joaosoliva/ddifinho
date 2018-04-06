using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBehaviorMG3 : ModelBehavior {

    Vector3 dist;
    float posX;
    float posY;

    void Start () {
        keeper = GameObject.Find("Keeper");
        modelManager = GameObject.FindObjectOfType(typeof(ModelManager)) as ModelManager;
        model = GetComponent<SpriteRenderer>();
        this.gameObject.transform.SetParent(keeper.transform, false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu carai");
        modelManager.cardsFliped.Add(gameObject);
        model.color = Color.red;
        modelManager.count++;
        if (modelManager.a == 0)
            modelManager.a = index;
        else
            modelManager.b = index;
    }

    public void OnMouseDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
    public override void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }
}

