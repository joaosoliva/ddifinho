using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayBasic : MonoBehaviour {

    [SerializeField]
    Transform frasco;

    [SerializeField]
    Sprite[] marcadores = new Sprite[3];

    [SerializeField]
    GameObject telascore;
    [SerializeField]
    Sprite star;
    [SerializeField]
    Sprite starEmpty;
    [Space]
    [SerializeField]
    internal TutorialBasic tutorialBasic;
    [SerializeField]
    internal GameObject tutorialQuestion;

    int rodada = 0;

    int acertos = 0;
    int erros = 0;

    string scoreDefacult_text;

    int tutorialMinigame;

    virtual internal void Start()
    {

    }

    virtual internal void Update()
    {

    }

    internal void Tutorial(int mg)
    {
        tutorialMinigame = mg;
        if (PlayerPrefs.GetInt("Tutorial_" + tutorialMinigame) == 0)
        {
            tutorialQuestion.SetActive(true);
        }
    }

    public void IniciarTutorial()
    {
        tutorialBasic.AbrirTutorial();
        tutorialBasic.IniciarTutorial(tutorialMinigame);
        tutorialQuestion.SetActive(false);
    }
    public void NaoFazerTutorial()
    {
        PlayerPrefs.SetInt("Tutorial_"+ tutorialMinigame, 1);
        tutorialQuestion.SetActive(false);
    }

    virtual internal void Inicializar()
    {
        rodada = 0;

        acertos = 0;
        erros = 0;
    }

    internal void Acerto()
    {
        frasco.GetChild(rodada).GetComponent<Image>().sprite = marcadores[1];
        acertos++;
        rodada++;
    }

    internal void Erro()
    {
        frasco.GetChild(rodada).GetComponent<Image>().sprite = marcadores[0];
        erros++;
        rodada++;
    }

    virtual internal bool ProximaRodada()
    {
        if (rodada == 5)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    virtual internal void FinalizarJogo(int minigame)
    {
        if (acertos <= 2)
        {
            //1 estrela
            if (PlayerPrefs.GetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade")) < 1)
            {
                PlayerPrefs.SetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade"), 1);
                Observador.AtualizarScore(1, minigame);
            }

            for (int i = 0; i < 1; i++)
            {
                telascore.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = star;
            }
        }

        else if (acertos >= 3 && acertos <= 4)
        {
            //2 estrelas
            if (PlayerPrefs.GetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade")) < 2)
            {
                PlayerPrefs.SetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade"), 2);
                Observador.AtualizarScore(2, minigame);
            }

            for (int i = 0; i < 2; i++)
            {
                telascore.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = star;
            }
        }

        else
        {
            //3 estrelas
            if (PlayerPrefs.GetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade")) < 3)
            {
                PlayerPrefs.SetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade"), 3);
                Observador.AtualizarScore(3, minigame);

            }

            for (int i = 0; i < 3; i++)
            {
                telascore.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = star;
            }
        }

        StartCoroutine(Score());

        telascore.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = scoreDefacult_text.Replace("xx", ((int)((acertos / 5f) * 100)).ToString());
    }

    virtual internal int SortearPergunta(int RangeMax)
    {
       return Random.Range(0, RangeMax);
    }

    internal int[] SortearResposta(int quantidade, int total)
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

        return selecionadas;
    }


    IEnumerator Score()
    {
        float time = Time.deltaTime;
        telascore.SetActive(true);
        while (telascore.GetComponent<RectTransform>().localScale.x < 1)
        {
            telascore.GetComponent<RectTransform>().localScale = new Vector3(time, time, time);
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }


    }

    virtual public void Repetir()
    {
        for (int i = 0; i < 3; i++)
        {
            telascore.transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = starEmpty;
        }

        for (int c = 0; c < 5; c++)
        {
            frasco.GetChild(c).GetComponent<Image>().sprite = marcadores[2];
        }

        telascore.SetActive(false);
        telascore.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        if (scoreDefacult_text == null)
        {
            scoreDefacult_text = telascore.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }

        telascore.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = scoreDefacult_text;
    }
}
