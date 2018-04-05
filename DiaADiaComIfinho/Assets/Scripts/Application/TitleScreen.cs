using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        
        if(Input.GetButtonDown("Submit"))
        {
            LoadingScreenManager.LoadScene(2);
        }
	}
}
