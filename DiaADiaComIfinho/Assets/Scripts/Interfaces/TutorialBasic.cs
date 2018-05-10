using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using TMPro;

public class TutorialBasic : MonoBehaviour {

    public enum Minigame { Um = 1, Dois, Tres, Quatro, Cinco, Seis };
    Minigame mg;

    int[] RMG1 = { 0,4};
    int Nselecionado = 0;

    [SerializeField]
    RectTransform Seletor;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    CanvasGroup FinalizarBox;

    //Variáveis especializadas
    Vector2 SeletorRelativePosMg1 = new Vector2(110, -82);
    Vector2 SeletorRelativePosMg2 = new Vector2(1580, -792);

    // Use this for initialization
    void Start () {
        //IniciarTutorial(5);
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AbrirTutorial()
    {
        gameObject.SetActive(true);
        StartCoroutine(Abrir());
    }

    public void FecharTutorial()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        StartCoroutine(Fechar());
    }

    IEnumerator Abrir()
    {
        float time = 0;
        while (gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = time;
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Fechar()
    {
        float time = 1;
        while (gameObject.GetComponent<CanvasGroup>().alpha > 0)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = time;
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        PlayerPrefs.SetInt("Tutorial_"+(int)(mg), 1);
        gameObject.SetActive(false);
    }

    public void IniciarTutorial(int number)
    {
        Nselecionado = 0;

        #region Bloco Especializado
        mg = (Minigame)number;
        switch (mg)
        {
            case Minigame.Um:
                transform.GetChild((int)mg).gameObject.SetActive(true);
                StartCoroutine(Iniciar());
                break;
            case Minigame.Dois:
                transform.GetChild((int)mg).gameObject.SetActive(true);
                StartCoroutine(Iniciar());
                break;
            case Minigame.Tres:
                transform.GetChild((int)mg).gameObject.SetActive(true);
                StartCoroutine(Iniciar());
                break;
            case Minigame.Quatro:
                transform.GetChild((int)mg).gameObject.SetActive(true);
                StartCoroutine(Iniciar());
                break;
            case Minigame.Cinco:
                transform.GetChild((int)mg).gameObject.SetActive(true);
                StartCoroutine(Iniciar());
                break;
        }
        #endregion

    }

    public void Repetir()
    {
        IniciarTutorial((int)mg);
    }

    public void Voltar()
    {

    }

    void FinalizarTutorial()
    {
        StartCoroutine(Finalizar());
    }

    IEnumerator Iniciar()
    {
        #region Zera Variaveis
        Seletor.GetComponent<Image>().CrossFadeAlpha(0f, 0.1f, true);
        textMeshProUGUI.CrossFadeAlpha(0f, 0.1f, true);

        FinalizarBox.alpha = 0;
        FinalizarBox.interactable = false;
        FinalizarBox.blocksRaycasts = false;

        #region Bloco Especializado
        if ((int)mg == 1)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[0]).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }

        else if ((int)mg == 2)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(0).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }

        else if ((int)mg == 3)
        {
            //transform.GetChild((int)mg).GetChild(0).GetChild(0).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }
        
        else if ((int)mg == 4)
        {
            transform.GetChild((int)mg).GetChild(1).GetChild(1).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }
        else if ((int)mg == 5)
        {
            transform.GetChild((int)mg).GetChild(1).GetChild(2).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }

        #endregion
        #endregion

        yield return new WaitForEndOfFrame();

        Seletor.GetComponent<Image>().CrossFadeAlpha(1f, 1f, true);
        textMeshProUGUI.CrossFadeAlpha(1f, 1f, true);

        #region Bloco Especializado
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Idiomas/" + PlayerPrefs.GetString("Lingua")).ToString());
        switch (mg)
        {
            case Minigame.Um:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG1").InnerText;
                break;
            case Minigame.Dois:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG2").InnerText;
                break;
            case Minigame.Tres:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG3").InnerText;
                break;
            case Minigame.Quatro:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG4").InnerText;
                break;
            case Minigame.Cinco:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG5").InnerText;
                break;
        }

        if ((int)mg == 1)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[0]).GetComponent<Button>().interactable = true;
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = false;
            StartCoroutine(IndicarBotao(RMG1[0], Nselecionado));
        }

        else if ((int)mg == 2)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<Button>().interactable = false;
            StartCoroutine(IndicarBotao(4, Nselecionado));
            transform.GetChild((int)mg).GetChild(0).GetChild(4).GetChild(0).GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Pawn");
        }

        else if ((int)mg == 3)
        {
            StartCoroutine(IndicarBotao(2, Nselecionado));
        }

        else if ((int)mg == 4)
        {
            transform.GetChild((int)mg).GetChild(0).GetComponent<TextMeshProUGUI>().text = doc.SelectSingleNode("//Minigame4/Feliz").InnerText;
            transform.GetChild((int)mg).GetChild(1).GetChild(1).GetComponent<Button>().interactable = true;
            StartCoroutine(IndicarBotao(1, Nselecionado));
        }

        else if ((int)mg == 5)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = doc.SelectSingleNode("//Minigame5/Azul").InnerText;
            transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontMaterial.SetColor("_OutlineColor", new Color(0, 0, 1f/3f, 1));
            transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontMaterial.SetColor("_FaceColor", new Color(0,0,1,1));

            transform.GetChild((int)mg).GetChild(1).GetChild(2).GetComponent<Button>().interactable = true;
            StartCoroutine(IndicarBotao(2, Nselecionado));
        }

        #endregion

        float time = 0;
        while (transform.GetChild((int)mg).GetComponent<CanvasGroup>().alpha < 1)
        {
            transform.GetChild((int)mg).GetComponent<CanvasGroup>().alpha = time;
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        transform.GetChild((int)mg).GetComponent<CanvasGroup>().interactable = true;
        transform.GetChild((int)mg).GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Selecionar(int i)
    {
        //StartCoroutine(SelecionarBotao(i));

        #region Bloco Especializado
        if ((int)mg == 1)
        {
            StartCoroutine(SelecionarBotao(i));
            Nselecionado++;

            if (Nselecionado == 2)
            {
                transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = false;
                FinalizarTutorial();
            }
            else
            {
                transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[0]).GetComponent<Button>().interactable = false;
                transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = true;
                StartCoroutine(IndicarBotao(RMG1[1], Nselecionado));
            }
        }

        else if ((int)mg == 2)
        {
            if (Nselecionado == 1 && i == 0)
            {
                StartCoroutine(SelecionarBotao(i));
                transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<Button>().interactable = false;
                FinalizarTutorial();
            }
            else if (Nselecionado == 0 && i == 4)
            {
                transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<Button>().interactable = true;
                Nselecionado++;
                StartCoroutine(IndicarBotao(0, Nselecionado));
            }
        }

        else if ((int)mg == 3)
        {
            if (Nselecionado == 0 && i == 0)
            {
                FinalizarTutorial();
            }
        }

        else if ((int)mg == 4)
        {
            if (Nselecionado == 0 && i == 1)
            {
                StartCoroutine(SelecionarBotao(i));
                FinalizarTutorial();
            }
        }

        else if ((int)mg == 5){
            if (Nselecionado == 0 && i == 2)
            {
                StartCoroutine(SelecionarBotao(i));
                FinalizarTutorial();
            }
        }


        #endregion
    }

    IEnumerator SelecionarBotao(int i)
    {
            float time = Time.deltaTime;
        Image aux;
        #region Bloco Especializado
        if ((int)mg == 1 || (int)mg == 2)
        {
            aux = transform.GetChild((int)mg).GetChild(0).GetChild(i).transform.GetChild(1).GetComponent<Image>();
            transform.GetChild((int)mg).GetChild(0).GetChild(i).GetComponent<Button>().interactable = false;
        }
        else if ((int)mg == 4 || (int)mg == 5)
        {
            aux = transform.GetChild((int)mg).GetChild(1).GetChild(i).transform.GetChild(1).GetComponent<Image>();
            transform.GetChild((int)mg).GetChild(1).GetChild(i).GetComponent<Button>().interactable = false;
        }

        else
        {
            aux = null;
        }
        #endregion
            while (aux.fillAmount != 1)
            {
                aux.fillAmount = time;
                time += Time.deltaTime * 1.5f;
                yield return new WaitForFixedUpdate();
            }
    }
    
    IEnumerator IndicarBotao(int i, int aux)
    {
        #region Bloco Especializado
        if ((int)mg == 1)
        {
            Vector2 target = transform.GetChild((int)mg).GetChild(0).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            target.x += 150f;
            target.y -= 150f;

            Seletor.anchoredPosition = target + SeletorRelativePosMg1;
        }

        else if ((int)mg == 2)
        {
            if (Nselecionado == 0)
            {
                Vector2 target = transform.GetChild((int)mg).GetChild(0).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                target.x += 300f;
                target.y -= 300f;

                Seletor.anchoredPosition = target + SeletorRelativePosMg2;
            }

            else
            {
                Vector2 target = transform.GetChild((int)mg).GetChild(0).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                target.x += 150f;
                target.y -= 150f;

                //Gambiarra
                Seletor.anchoredPosition = target + SeletorRelativePosMg1;
            }
        }

        else if ((int)mg == 3)
        {
            Vector2 target = transform.GetChild((int)mg).GetChild(1).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            target.x += 150f;
            target.y -= 150f;

            //gambiarra
            Seletor.anchoredPosition = target + SeletorRelativePosMg1;
        }

        else if ((int)mg == 4)
        {
            Vector2 target = transform.GetChild((int)mg).GetChild(1).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            target.x += 150f;
            target.y -= 150f;

            //gambirra
            Seletor.anchoredPosition = target + SeletorRelativePosMg1;
        }

        else if ((int)mg == 5)
        {
            Vector2 target = transform.GetChild((int)mg).GetChild(1).GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            target.x += 150f;
            target.y -= 150f;

            //gambirra
            Seletor.anchoredPosition = target + SeletorRelativePosMg1;
        }

        #endregion

        float time = 1;
        bool sentido = true;
        while (Nselecionado == aux)
        {
            if (time < 0)
            {
                time = 0;
                sentido = false;
            }
            else if (time > 1)
            {
                time = 1;
                sentido = true;
            }

            Seletor.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.5f, time);

            if (sentido)
            {
                time -= Time.deltaTime;
            }

            else
            {
                time += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }

    }

    IEnumerator Finalizar()
    {
        Seletor.GetComponent<Image>().CrossFadeAlpha(0f, 0.1f, true);
        textMeshProUGUI.CrossFadeAlpha(0f, 0.1f, true);

        float time = 0;
        while (FinalizarBox.alpha < 1)
        {
            time += Time.deltaTime*1.5f;
            FinalizarBox.alpha = time;
            yield return new WaitForFixedUpdate();
        }
        FinalizarBox.interactable = true;
        FinalizarBox.blocksRaycasts = true;
    }
}
