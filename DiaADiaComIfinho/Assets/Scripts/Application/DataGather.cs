using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataGather : MonoBehaviour {

    public AudioClip btnClick;
    private GameObject difficultLayout, dataLayout;

    public void Start()
    {
        difficultLayout = GameObject.Find("Difficult");
        dataLayout = GameObject.Find("Data");
        difficultLayout.SetActive(false);
    }
    public void Back()
    {
        SoundManager.instance.PlaySingle(btnClick);
        LoadingScreenManager.LoadScene(2);
    }

    public void OkBtn()
    {
        SoundManager.instance.PlaySingle(btnClick);
        dataLayout.SetActive(false);
        difficultLayout.SetActive(true);
    }
    public void OkDifficultBtn()
    {
        SoundManager.instance.PlaySingle(btnClick);
        LoadingScreenManager.LoadScene(4);
    }
    public void BackDifficultBtn()
    {
        SoundManager.instance.PlaySingle(btnClick);
        dataLayout.SetActive(true);
        difficultLayout.SetActive(false);
    }
}
