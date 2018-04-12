using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public const int total_minigames = 6;

    [SerializeField]
    Button continuar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckSave()
    {
        //verificar se tem algum jogo salvo

        if (PlayerPrefs.GetInt("SaveGame") == 0)
        {
            continuar.interactable = false;
        }

        else
        {
            continuar.interactable = true;
        }
    }

    void Continue()
    {

    }

    public void NewGame()
    {
        for (int i = 0; i < total_minigames; i++)
        {
            PlayerPrefs.DeleteKey("Score_Minigame_" + i + "_easy");
            PlayerPrefs.DeleteKey("Score_Minigame_" + i + "_normal");
            PlayerPrefs.DeleteKey("Score_Minigame_" + i + "_hard");
        }

        PlayerPrefs.DeleteKey("Dificuldade");
        PlayerPrefs.SetInt("SaveGame", 0);
    }

    void Option()
    {

    }

    public void Sair()
    {
        Application.Quit();
    }
}
