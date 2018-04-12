using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour {

    bool autismo = true;
    [SerializeField]
    TMP_Dropdown dropdown;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toogle(bool autismo)
    {
        this.autismo = autismo;
    }

    public void Ok()
    {
        Observador.CriarUsuario(dropdown.captionText.text,autismo.ToString());
    }

}
