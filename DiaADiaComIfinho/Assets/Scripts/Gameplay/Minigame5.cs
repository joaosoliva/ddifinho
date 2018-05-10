using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;

public class Minigame5 : GamePlayBasic {

    [SerializeField]
    GameObject[] slots = new GameObject[10];

    int[] selecionados;

    int pergunta;

    int[] respostas;
    int[] cores;


    [SerializeField]
    Sprite[] respostasPossiveis;
    [SerializeField]
    Color[] coresPossiveis;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    Image amostra;
    // Use this for initialization
    override internal void Start()
    {
        Tutorial(5);

        Inicializar();

    }

    // Update is called once per frame
    override internal void Update()
    {

    }

    //Inicializar rodada
    override internal void Inicializar()
    {

        float escala;
        /* Sorteamos N respostas e cores depois entre as respostas sorteamos uma pergunta
         * Dependendo da dificuldade escolhida nós aumentamos o numero de elementos e randomizamos sua escala
         */

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                selecionados = new int[1] { -1};
                cores = SortearResposta(3, coresPossiveis.Length);
                respostas = SortearResposta(3, respostasPossiveis.Length);
                pergunta = SortearPergunta(1, 3);

                for (int i = 0; i < 3; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = coresPossiveis[cores[i]];
                }
                break;

            case "normal":
                selecionados = new int[2] { -1, -1 };
                cores = SortearResposta(4, coresPossiveis.Length);
                respostas = SortearResposta(4, respostasPossiveis.Length);
                pergunta = SortearPergunta(2,4);

                for (int i = 0; i < 4; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = coresPossiveis[cores[i]];
                }
                break;

            case "hard":
                selecionados = new int[2] { -1, -1 };
                cores = SortearResposta(4, coresPossiveis.Length);
                respostas = SortearResposta(4, respostasPossiveis.Length);
                pergunta = SortearPergunta(2,4);

                for (int i = 0; i < 4; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    escala = Random.Range(0.3f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(escala, escala, escala);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = coresPossiveis[cores[i]];
                }
                break;
        }
    }

    internal int SortearPergunta(int quantidade, int total)
    {
        /* Retorna um array com as respostas sorteadas
         * Primeiro recebemos o total de respostas possíveis de onde sortearemos os indices 
         * que irão preencher o array de respostas selecionadas
         * */
        int[] selecionadas = new int[quantidade];
        int nSelecionados = 0;
        int indiceAux;
        List<int> fonte = new List<int>();

        for (int i = 0; i < total; i++)
        {
            fonte.Add(i);
        }

        while (nSelecionados < quantidade)
        {
            indiceAux = Random.Range(0, (int)fonte.Count);
            selecionadas[nSelecionados] = fonte[indiceAux];
            fonte.RemoveAt(indiceAux);
            nSelecionados++;
        }

        if (quantidade == 2)
        {
            cores[selecionadas[1]] = cores[selecionadas[0]];
        }

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Idiomas/" + PlayerPrefs.GetString("Lingua")).ToString());

        switch (cores[selecionadas[0]])
        {
            case 0:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Azul").InnerText;
                break;
            case 1:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Amarelo").InnerText;
                break;
            case 2:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Vermelho").InnerText;
                break;
            case 3:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Verde").InnerText;
                break;
            case 4:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Laranja").InnerText;
                break;
            case 5:
                textMeshProUGUI.text = doc.SelectSingleNode("//Minigame5/Violeta").InnerText;
                break;
        }

        amostra.color = coresPossiveis[cores[selecionadas[0]]];
        textMeshProUGUI.fontMaterial.SetColor("_OutlineColor", new Color(coresPossiveis[cores[selecionadas[0]]].r / 3, coresPossiveis[cores[selecionadas[0]]].g / 3, coresPossiveis[cores[selecionadas[0]]].b / 3,1));
        textMeshProUGUI.fontMaterial.SetColor("_FaceColor", coresPossiveis[cores[selecionadas[0]]]);

        return cores[selecionadas[0]];
    }

    public void Selecionar(int id)
    {
        //Verificar se algum elemento não foi selecionado
        if (selecionados[0] == -1)
        {
            selecionados[0] = id;
            StartCoroutine(AnimationSelect(id, true));
            if (selecionados.Length == 1)
            {
                VerificarResposta();
            }
        }

        else if (selecionados[1] == -1 && selecionados[0] != id)
        {
            selecionados[1] = id;
            StartCoroutine(AnimationSelect(id, true));
            VerificarResposta();
        }

        //Verificar se nenhum elemento selecionado é igual ao id novo
        else if (selecionados[0] == id)
        {

            selecionados[0] = -1;
            StartCoroutine(AnimationSelect(id, false));

        }
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
        if (selecionados.Length == 2)
        {
            if (slots[selecionados[0]].transform.GetChild(0).GetComponent<Image>().color == coresPossiveis[pergunta] &&
                slots[selecionados[1]].transform.GetChild(0).GetComponent<Image>().color == coresPossiveis[pergunta])
            {
                base.Acerto();
            }

            else
            {
                base.Erro();
            }
        }
        else
        {
            if (slots[selecionados[0]].transform.GetChild(0).GetComponent<Image>().color == coresPossiveis[pergunta])
            {
                base.Acerto();
            }

            else
            {
                base.Erro();
            }
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
                amostra.CrossFadeAlpha(0f, 0.75f, true);
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
                amostra.CrossFadeAlpha(1f, 0.5f, true);
            }

            Inicializar();
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
            base.FinalizarJogo(5);
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
            amostra.CrossFadeAlpha(1f, 0.5f, true);
        }

        Inicializar();

        base.Inicializar();
    }
}
