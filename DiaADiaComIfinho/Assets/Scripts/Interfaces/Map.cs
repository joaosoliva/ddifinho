using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    [SerializeField]
    Scrollbar scrollbar;

    float targetValue;

    [SerializeField]
    Button left;
    [SerializeField]
    Button right;

    [SerializeField]
    Image fundo;

    [SerializeField]
    Transform view;


    [Header("Scores")]
    [SerializeField]
    GameObject[] scoreMinigame = new GameObject[6];

    [Space]
    [SerializeField]
    Sprite FullStar;
    [SerializeField]
    Sprite EmptyStar;

    bool animate = false;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < view.GetChild(0).childCount; i++)
        {
            view.GetChild(0).GetChild(i).GetComponent<LayoutElement>().minHeight = view.GetComponent<RectTransform>().rect.height;
            view.GetChild(0).GetChild(i).GetComponent<LayoutElement>().minWidth = view.GetComponent<RectTransform>().rect.width;

        }

        scrollbar.value = 0;

        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            LoadScore();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScore()
    {
        for (int i = 0; i < scoreMinigame.Length; i++)
        {
            for (int c = 0; c < 3; c++)
            {
                scoreMinigame[i].transform.GetChild(c).GetComponent<Image>().sprite = EmptyStar;
            }
        }

        for (int i = 0; i < scoreMinigame.Length; i++)
        {
            for (int c = 0; c < PlayerPrefs.GetInt("Score_Minigame_" + (i+1) + "_" + PlayerPrefs.GetString("Dificuldade")); c++)
            {
                scoreMinigame[i].transform.GetChild(c).GetComponent<Image>().sprite = FullStar;
            }
        }
    }

    public void Left()
    {
        if (animate == false)
        {
            targetValue = scrollbar.value - 0.5f;

            if (targetValue <= 0)
            {
                left.interactable = false;
                targetValue = 0;
            }

            else
            {
                right.interactable = true;
            }

            StartCoroutine(AnimScroll());
        }
    }

    public void Right()
    {
        if (animate == false)
        {
            targetValue = scrollbar.value + 0.5f;

            if (targetValue >= 1)
            {
                right.interactable = false;
                targetValue = 1;
            }

            else
            {
                left.interactable = true;
            }

            StartCoroutine(AnimScroll());
        }
    }

    IEnumerator AnimScroll()
    {
        animate = true;
        Color targetBackground = new Color();
        if (targetValue == 0)
        {
            //manhã
            ColorUtility.TryParseHtmlString("#C1EAEDFF", out targetBackground);

        }

        else if (targetValue == 0.5f)
        {
            //tarde
            ColorUtility.TryParseHtmlString("#9BD0F3FF", out targetBackground);

            //if (ColorUtility.TryParseHtmlString("#9BD0F3FF", out targetBackground))
            //{
                //Debug.Log("funciono");
            //}
        
            //else {
                //Debug.Log("deu ruim");
            //}

        }
        else if (targetValue == 1)
        {
            //noite
            ColorUtility.TryParseHtmlString("#4F79A2FF", out targetBackground);

        }

        float time = Time.deltaTime;
        while (scrollbar.value != targetValue)
        {
            yield return new WaitForFixedUpdate();

            fundo.color = Color.Lerp(fundo.color, targetBackground, time);

            scrollbar.value = (Mathf.Lerp(scrollbar.value, targetValue, time));

            time += Time.deltaTime;
        }

        animate = false;
    }
}
