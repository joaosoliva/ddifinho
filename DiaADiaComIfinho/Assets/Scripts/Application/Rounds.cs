using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour {

    public GameObject[] right, wrong;
    public bool finished = false;
    public int indexR, indexW;

	void Update () {

        if (finished)
        {
              indexR++;
              finished = false;
        }
	}
}
