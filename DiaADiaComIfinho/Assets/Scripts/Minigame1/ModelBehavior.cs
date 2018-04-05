using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelBehavior : MonoBehaviour
{
    [Header("Instancias")]
    public ModelManager modelManager;
    public GameObject keeper;
    protected SpriteRenderer model;

    [Header("Index de controle")]
    [SerializeField]
    protected int index;
   
    void Start () {
        keeper = GameObject.Find("Keeper");
        modelManager = GameObject.FindObjectOfType(typeof(ModelManager)) as ModelManager;
        model = GetComponent<SpriteRenderer>();
        this.gameObject.transform.SetParent(keeper.transform, false);
    }
    public virtual void OnMouseDown()
    {
        this.GetComponent<PolygonCollider2D>().enabled = false;
        modelManager.cardsFliped.Add(gameObject);
        model.color = Color.red;
        modelManager.count++;
        if (modelManager.a == 0)
            modelManager.a = index;
        else
            modelManager.b = index;   
    }
}


