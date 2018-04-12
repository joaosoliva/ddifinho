using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayBasic : MonoBehaviour {

    [SerializeField]
    Transform frasco;

    [SerializeField]
    Sprite[] marcadores = new Sprite[2];

    int rodada = 0;

    int acertos = 0;
    int erros = 0;

    virtual internal void Inicializar()
    {

    }

    internal void Acerto()
    {
        frasco.GetChild(rodada).GetComponent<Image>().sprite = marcadores[1];
        acertos++;
        rodada++;
        ProximaRodada();
    }

    internal void Erro()
    {
        frasco.GetChild(rodada).GetComponent<Image>().sprite = marcadores[0];
        erros++;
        rodada++;
        ProximaRodada();
    }

    virtual internal void ProximaRodada()
    {

        //Alternar os painéis de rodada

        //if rodada == 5 
            //FinalizarJogo
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
        }

        else if (acertos >= 3 && acertos <= 4)
        {
            //2 estrelas
            if (PlayerPrefs.GetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade")) < 2)
            {
                PlayerPrefs.SetInt("Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade"), 2);
                Observador.AtualizarScore(2, minigame);
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
        }
    }

    //Mudar o retorno de void para int ou int[]

    internal void SortearPergunta(int quantidade)
    {

    }

    internal void SortearResposta(int quantidade)
    {

    }
}
