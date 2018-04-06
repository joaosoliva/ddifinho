using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultChoose : MonoBehaviour{

    public int difficult;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Easy()
    {
        difficult = 1;
    }

    public void Normal()
    {

        difficult = 2;
    }

    public void Hard()
    {
        difficult = 3;
    }
}
