using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private Animator optionAnim,creditsAnim;
    private GameObject optionCanvas, creditsCanvas;
    public AudioClip btnClick;

	void Start () {
        creditsAnim = GameObject.Find("CreditsCanvas").GetComponent<Animator>();
        optionAnim = GameObject.Find("OptionsCanvas").GetComponent<Animator>();
        creditsCanvas = GameObject.Find("CreditsCanvas");
        optionCanvas = GameObject.Find("OptionsCanvas");
        creditsCanvas.gameObject.SetActive(false);
        optionCanvas.gameObject.SetActive(false);       
	}
	
    public void NewGame()
    {
        SoundManager.instance.PlaySingle(btnClick);
        LoadingScreenManager.LoadScene(3);
    }
    public void Continue()
    {
       
    }
    public void Credits()
    {
        SoundManager.instance.PlaySingle(btnClick);
        creditsCanvas.gameObject.SetActive(true);
        creditsAnim.Play(0);
    }
    public void Option()
    {
        SoundManager.instance.PlaySingle(btnClick);
        optionCanvas.gameObject.SetActive(true);
        optionAnim.Play(0);
    }
    public void Exit()
    {
        SoundManager.instance.PlaySingle(btnClick);
        Application.Quit();
    }
    public void Back()
    {
        SoundManager.instance.PlaySingle(btnClick);
        optionCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(false);
    }
    public void SoundControl(float newValue)
    {
        AudioListener.volume = newValue;
    }
    public void ChangeResolution(int newResolution)
    {
        if(newResolution == 0)
        {
            Screen.SetResolution(1366, 768, true);
        }
        else if(newResolution == 1)
        {
            Screen.SetResolution(1024, 768, true);
        }
        else if(newResolution == 2)
        {
            Screen.SetResolution(800, 600, false);
        }
    }
}
