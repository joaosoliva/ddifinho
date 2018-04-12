using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    [SerializeField]
    Slider slider;

    [SerializeField]
    Button[] lg = new Button[3];

    [SerializeField]
    Toggle[] df = new Toggle[3];

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSettings()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");

        switch (PlayerPrefs.GetString("Lingua"))
        {
            case "Portugues":
                lg[0].interactable = false;
                break;
            case "Espanhol":
                lg[1].interactable = false;
                break;
            case "Ingles":
                lg[2].interactable = false;
                break;
        }

        for (int i = 0; i < df.Length; i++)
        {
            df[i].isOn = false;
        }

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                df[0].isOn = true;
                break;
            case "normal":
                df[1].isOn = true;
                break;
            case "hard":
                df[2].isOn = true;
                break;
        }
    }

    public void SetVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("Volume",slider.value);
    }

    public void SetLanguage(string lg)
    {
        PlayerPrefs.SetString("Lingua", lg);

        for (int i = 0; i < this.lg.Length; i++)
        {
            this.lg[i].interactable = true;
        }

        switch (PlayerPrefs.GetString("Lingua"))
        {
            case "Portugues":
                this.lg[0].interactable = false;
                break;
            case "Espanhol":
                this.lg[1].interactable = false;
                break;
            case "Ingles":
                this.lg[2].interactable = false;
                break;
        }

        //adicionar função de autoajuste
    }

    public void SetDifficulty(string df)
    {
        PlayerPrefs.SetString("Dificuldade", df);
    }
}
