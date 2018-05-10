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

    // Use this for initialization
    void Start () {
        IniciarTutorial(Minigame.Um);
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void IniciarTutorial(Minigame number)
    {
        Nselecionado = 0;

        mg = number;
        switch (mg)
        {
            case Minigame.Um:
                StartCoroutine(Iniciar());
                break;
        }

    }

    public void Repetir()
    {
        IniciarTutorial(mg);
    }

    public void Continuar()
    {

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

        //Bloco especializado
        if ((int)mg == 1){
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[0]).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
        }
        #endregion

        yield return new WaitForEndOfFrame();

        float time = 0;
        while (transform.GetChild((int)mg).GetComponent<CanvasGroup>().alpha < 1)
        {
            transform.GetChild((int)mg).GetComponent<CanvasGroup>().alpha = time;
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        transform.GetChild((int)mg).GetComponent<CanvasGroup>().interactable = true;

        //Bloco especializado
        if ((int)mg == 1)
        {
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[0]).GetComponent<Button>().interactable = true;
            transform.GetChild((int)mg).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = false;
            StartCoroutine(IndicarBotao(RMG1[0], Nselecionado));
        }

        Seletor.GetComponent<Image>().CrossFadeAlpha(1f, 1f, true);
        textMeshProUGUI.CrossFadeAlpha(1f, 1f, true);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Idiomas/" + PlayerPrefs.GetString("Lingua")).ToString());
        switch (mg)
        {
            case Minigame.Um:
                textMeshProUGUI.text = doc.SelectSingleNode("//Tutorial/MG1").InnerText;
                break;
        }
    }

    public void Selecionar(int i)
    {
        StartCoroutine(SelecionarBotao(i));
        Nselecionado ++;

        //Bloco especializado
        if ((int)mg == 1)
        {
            if (Nselecionado == 2)
            {
                transform.GetChild(1).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = false;
                FinalizarTutorial();
            }
            else
            {
                transform.GetChild(1).GetChild(0).GetChild(RMG1[0]).GetComponent<Button>().interactable = false;
                transform.GetChild(1).GetChild(0).GetChild(RMG1[1]).GetComponent<Button>().interactable = true;
                StartCoroutine(IndicarBotao(RMG1[1], Nselecionado));
            }
        }
    }

    IEnumerator SelecionarBotao(int i)
    {
            float time = Time.deltaTime;
            Image aux = transform.GetChild((int)mg).GetChild(0).GetChild(i).transform.GetChild(1).GetComponent<Image>();

            transform.GetChild((int)mg).GetChild(0).GetChild(0).GetComponent<Button>().interactable = false;

            while (aux.fillAmount != 1)
            {
                aux.fillAmount = time;
                time += Time.deltaTime * 1.5f;
                yield return new WaitForFixedUpdate();
            }
    }
    
    IEnumerator IndicarBotao(int i, int aux)
    {
        Vector2 target = transform.GetChild((int)mg).GetChild(0).GetChild(i).GetComponent<RectTransform>().anchoredPosition;

        target.x += 150f;
        target.y -= 150f;

        //Bloco especializado
        if ((int)mg == 1)
        {
            Seletor.anchoredPosition = target + SeletorRelativePosMg1;
        }

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
