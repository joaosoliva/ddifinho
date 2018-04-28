using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDifficulty(string df)
    {
        PlayerPrefs.SetString("Dificuldade",df);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("SaveGame", 1);

        Observador.OficializarUsuario();
    }
}
