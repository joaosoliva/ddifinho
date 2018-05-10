using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame3 : GamePlayBasic{



    [SerializeField]
    GameObject[] slots = new GameObject[3];

    int selecionado = -1;

    #region Possivel generalizar
    int pergunta;
    int[] respostas;
    #endregion

    [SerializeField]
    Sprite[] respostasPossiveis;

    [SerializeField]
    Image Pergunta;

    // Use this for initialization
    override internal void Start()
    {
        Tutorial(3);
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

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                respostas = SortearResposta(2, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 2; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }

                Pergunta.sprite = respostasPossiveis[pergunta];
                break;

            case "normal":
                respostas = SortearResposta(3, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 3; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }

                Pergunta.sprite = respostasPossiveis[pergunta];
                break;

            case "hard":
                respostas = SortearResposta(3, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                for (int i = 0; i < 3; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    escala = Random.Range(0.3f, 1f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(escala, escala, escala);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }

                Pergunta.sprite = respostasPossiveis[pergunta];
                break;
        }
    }

    internal override int SortearPergunta(int RangeMax)
    {
        return respostas[Random.Range(0, respostas.Length)];
    }

    public void Selecionar(int id)
    {
        selecionado = id;
    }

    public void ConfirmarSelecao()
    {
        VerificarResposta();
    }

    void VerificarResposta()
    {
        if (slots[selecionado].transform.GetChild(0).GetComponent<Image>().sprite == respostasPossiveis[pergunta])
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
                slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0f, 0.75f, true);
            }

            while (time >= 0)
            {
                yield return new WaitForFixedUpdate();
                time -= Time.deltaTime;
            }


            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetActive(false);
                slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
            }

            Inicializar();
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<ObjectDragHandler>().enabled = false;
            }
            base.FinalizarJogo(3);
        }
    }

    public override void Repetir()
    {
        base.Repetir();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
            slots[i].GetComponent<ObjectDragHandler>().enabled = true;
            slots[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        }

        Inicializar();

        base.Inicializar();
    }
}
