using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame2 : GamePlayBasic {

    [SerializeField]
    GameObject[] slots = new GameObject[6];

    [SerializeField]
    AudioSource audioSource;

    int selecionado = -1;
    int pergunta;
    int[] respostas;

    //O indice das perguntas e das respostas deve ser igual
    [SerializeField]
    Sprite[] respostasPossiveis;

    AudioClip[] perguntasPossiveis = new AudioClip[8];

    // Use this for initialization
    override internal void Start()
    {
        #region Carregar audios de acordo com a lingua
        perguntasPossiveis[0] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Book");
        perguntasPossiveis[1] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Car");
        perguntasPossiveis[2] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Chess");
        perguntasPossiveis[3] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Doll");
        perguntasPossiveis[4] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Kite");
        perguntasPossiveis[5] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Notebook");
        perguntasPossiveis[6] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Pawn");
        perguntasPossiveis[7] = Resources.Load<AudioClip>("Minigames/2/" + PlayerPrefs.GetString("Lingua") + "/Pencil");
        #endregion

        Inicializar();
    }

    // Update is called once per frame
    override internal void Update()
    {

    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    //Inicializar rodada
    override internal void Inicializar()
    {
        selecionado = -1;
        /* Sorteamos N respostas e depois entre as respostas sorteamos uma pergunta, que será tanto o ID
         * que utilizaremos para comparar as sprites da resposta com a pergunta quanto para selecionarmos
         * o AudioClip nas perguntasPossiveis
         * Dependendo da dificuldade escolhida nós aumentamos o numero
         */

        switch (PlayerPrefs.GetString("Dificuldade"))
        {
            case "easy":
                respostas = SortearResposta(4, respostasPossiveis.Length);
                //Sorteia qual das respostas será a pergunta
                pergunta = SortearPergunta(-1);

                audioSource.clip = perguntasPossiveis[pergunta];

                for (int i = 0; i < 4; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 1;
                break;

            case "normal":
                respostas = SortearResposta(5, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                audioSource.clip = perguntasPossiveis[pergunta];

                for (int i = 0; i < 5; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 1;
                break;

            case "hard":
                respostas = SortearResposta(6, respostasPossiveis.Length);
                pergunta = SortearPergunta(-1);

                audioSource.clip = perguntasPossiveis[pergunta];

                for (int i = 0; i < 6; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = respostasPossiveis[respostas[i]];
                }
                transform.GetChild(1).GetComponent<GridLayoutGroup>().constraintCount = 2;
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

            PlayAudio();
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
            base.FinalizarJogo(2);
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

        PlayAudio();
    }

    public void Iniciar()
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

