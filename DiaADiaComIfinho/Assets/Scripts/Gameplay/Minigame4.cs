using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;

public class Minigame4 : GamePlayBasic{


    [SerializeField]
    GameObject[] slots = new GameObject[10];

    int selecionado = -1;

    int pergunta;

    int[] respostas;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    [Space]
    [SerializeField]
    Sprite[] respostaFeliz;
    [SerializeField]
    Sprite[] respostaTriste;
    [SerializeField]
    Sprite[] respostaIndiferente;
    [SerializeField]
    Sprite[] respostaAssustado;
    [SerializeField]
    Sprite[] respostaZangado;
    [SerializeField]
    Sprite[] respostaSorridente;
    [SerializeField]
    Sprite[] respostaSurpreso;

    // Use this for initialization
    override internal void Start()
    {
        Tutorial(4);
 
        Inicializar();
    }

    // Update is called once per frame
    override internal void Update()
    {

    }

    //Inicializar rodada
    override internal void Inicializar()
    {
        selecionado = -1;
        /* Sorteamos N respostas e depois entre as respostas sorteamos uma pergunta/cópia
         * Depois colocamos a pergunta/cópia dentro das respostas de forma randomica
         * Dependendo da dificuldade escolhida nós aumentamos o numero de elementos e randomizamos sua escala
         */

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                respostas = SortearResposta(3, 7);
                //Sorteia o indice da cópia
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 3; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    switch (respostas[i])
                    {
                        case 0:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaFeliz[Random.Range(0,respostaFeliz.Length)];
                            break;
                        case 1:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaTriste[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 2:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaIndiferente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 3:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaAssustado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 4:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaZangado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 5:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSorridente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 6:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSurpreso[Random.Range(0, respostaFeliz.Length)];
                            break;
                    }
                    
                }
                break;

            case "normal":
                respostas = SortearResposta(4, 7);
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 4; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    switch (respostas[i])
                    {
                        case 0:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaFeliz[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 1:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaTriste[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 2:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaIndiferente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 3:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaAssustado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 4:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaZangado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 5:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSorridente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 6:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSurpreso[Random.Range(0, respostaFeliz.Length)];
                            break;
                    }
                }
                break;

            case "hard":
                respostas = SortearResposta(5, 7);
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 5; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1,1, 1);
                    switch (respostas[i])
                    {
                        case 0:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaFeliz[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 1:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaTriste[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 2:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaIndiferente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 3:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaAssustado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 4:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaZangado[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 5:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSorridente[Random.Range(0, respostaFeliz.Length)];
                            break;
                        case 6:
                            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostaSurpreso[Random.Range(0, respostaFeliz.Length)];
                            break;
                    }
                }
                break;
        }
    }

    internal override int SortearPergunta(int RangeMax)
    {
        int aux = Random.Range(0, respostas.Length);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Idiomas/" + PlayerPrefs.GetString("Lingua")).ToString());

        switch (respostas[aux])
        {
            case 0:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Feliz").InnerText;
                break;
            case 1:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Triste").InnerText;
                break;
            case 2:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Indiferente").InnerText;
                break;
            case 3:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Assustado").InnerText;
                break;
            case 4:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Zangado").InnerText;
                break;
            case 5:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Sorridente").InnerText;
                break;
            case 6:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame4/Surpreso").InnerText;
                break;
        }

        return aux;
    }

    public void Selecionar(int id)
    {
        selecionado = id;
        StartCoroutine(AnimationSelect(id, true));
        VerificarResposta();
    }

    IEnumerator AnimationSelect(int i, bool sentido)
    {
        if (sentido)
        {
            float time = Time.deltaTime;
            Image aux = slots[i].transform.GetChild(1).GetComponent<Image>();

            while (aux.fillAmount != 1)
            {
                aux.fillAmount = time;
                time += Time.deltaTime * 1.5f;
                yield return new WaitForFixedUpdate();
            }
        }

        else
        {
            float time = 1f;
            Image aux = slots[i].transform.GetChild(1).GetComponent<Image>();

            while (aux.fillAmount > 0)
            {
                aux.fillAmount = time;
                time -= Time.deltaTime * 1.5f;
                yield return new WaitForFixedUpdate();
            }
        }
    }

    void VerificarResposta()
    {
        if (respostas[selecionado] == respostas[pergunta])
        {
            base.Acerto();
        }

        else
        {
            base.Erro();
        }

        StartCoroutine(ProximaRodadaEspecifico());
    }


    IEnumerator ProximaRodadaEspecifico()
    {
        float time = 1;

        if (base.ProximaRodada())
        {

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Button>().interactable = false;
                slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0f, 0.75f, true);
                slots[i].transform.GetChild(1).GetComponent<Image>().CrossFadeAlpha(0f, 0.75f, true);
                textMeshProUGUI.CrossFadeAlpha(0f, 0.75f, true);
            }

            while (time >= 0)
            {
                yield return new WaitForFixedUpdate();
                time -= Time.deltaTime;
            }


            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetActive(false);
                slots[i].GetComponent<Button>().interactable = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
                slots[i].transform.GetChild(1).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
                slots[i].transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
                textMeshProUGUI.CrossFadeAlpha(1f, 0.5f, true);
            }

            Inicializar();
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
            base.FinalizarJogo(4);
        }
    }

    public override void Repetir()
    {
        base.Repetir();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
            slots[i].GetComponent<Button>().interactable = true;
            slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
            slots[i].transform.GetChild(1).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
            slots[i].transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
            textMeshProUGUI.CrossFadeAlpha(1f, 0.5f, true);
        }

        Inicializar();

        base.Inicializar();
    }
}

