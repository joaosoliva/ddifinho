using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Verificação genérica/ suporte a linguagens não previstas
        //if (PlayerPrefs.GetString("Lingua") == "")
        //      {
        //          transform.parent.GetComponent<Animator>().Play("Linguagem_open");
        //      }

        //      else
        //      {
        //          transform.parent.GetComponent<Animator>().Play("MainScreen_Open");
        //      }

        switch (PlayerPrefs.GetString("Lingua"))
        {
            case "Portugues":
                Debug.Log("Linguagem em PT escolhida");
                transform.parent.GetComponent<Animator>().Play("MainScreen_Open");
                break;
            case "Espanhol":
                Debug.Log("Linguagem em ES escolhida");
                transform.parent.GetComponent<Animator>().Play("MainScreen_Open");
                break;
            case "Ingles":
                Debug.Log("Linguagem em EN escolhida");
                transform.parent.GetComponent<Animator>().Play("MainScreen_Open");
                break;
            default:
                transform.parent.GetComponent<Animator>().Play("Linguagem_open");
                PlayerPrefs.SetFloat("Volume", 0.5f);
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PT()
    {
        PlayerPrefs.SetString("Lingua", "Portugues");
    }

    public void ES()
    {
        PlayerPrefs.SetString("Lingua", "Espanhol");
    }

    public void EN()
    {
        PlayerPrefs.SetString("Lingua", "Ingles");
    }
}
