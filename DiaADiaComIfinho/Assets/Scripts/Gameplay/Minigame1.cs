using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : GamePlayBasic
{

    [SerializeField]
    GameObject[] slots = new GameObject[10];

    int[] selecionados = new int[2] { -1, -1 };

    int pergunta;

    int[] respostas;

    List<int> Elementos = new List<int>();

    [SerializeField]
    Sprite[] respostasPossiveis;

    // Use this for initialization
    override internal void Start()
    {

        //for (int i = 0; i < transform.GetChild(1).childCount; i++)
        //{
        //    slots[i] = transform.GetChild(1).GetChild(i).gameObject;
        //}

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
        selecionados[0] = -1;
        selecionados[1] = -1;
        /* Sorteamos N respostas e depois entre as respostas sorteamos uma pergunta/cópia
         * Depois colocamos a pergunta/cópia dentro das respostas de forma randomica
         * Dependendo da dificuldade escolhida nós aumentamos o numero de elementos e randomizamos sua escala
         */

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                respostas = SortearResposta(5, respostasPossiveis.Length);
                //Sorteia o indice da cópia
                pergunta = SortearPergunta(-1);

                Elementos = new List<int>(respostas);
                Elementos.Insert(Random.Range(0, respostas.Length), pergunta);
                for (int i = 0; i < 6; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[Elementos[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 3;
                break;

            case "normal":
                respostas = SortearResposta(7, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                Elementos = new List<int>(respostas);
                Elementos.Insert(Random.Range(0, respostas.Length), pergunta);
                for (int i = 0; i < 8; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    escala = Random.Range(0.3f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(escala, escala, escala);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[Elementos[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 4;
                break;

            case "hard":
                respostas = SortearResposta(9, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                Elementos = new List<int>(respostas);
                Elementos.Insert(Random.Range(0, respostas.Length), pergunta);
                for (int i = 0; i < 10; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    escala = Random.Range(0.3f, 0.85f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(escala, escala, escala);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[Elementos[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 5;
                break;
        }
    }

    internal override int SortearPergunta(int RangeMax)
    {
        return respostas[Random.Range(0, respostas.Length)];
    }

    public void Selecionar(int id)
    {
        //Verificar se algum elemento não foi selecionado
        if (selecionados[0] == -1)
        {
            selecionados[0] = id;
            StartCoroutine(AnimationSelect(id, true));
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
        if (slots[selecionados[0]].transform.GetChild(0).GetComponent<Image>().sprite == respostasPossiveis[pergunta] &&
            slots[selecionados[1]].transform.GetChild(0).GetComponent<Image>().sprite == respostasPossiveis[pergunta])
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
            }

            Inicializar();
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
                base.FinalizarJogo(1);
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
        }

        Inicializar();

        base.Inicializar();
    }
}
