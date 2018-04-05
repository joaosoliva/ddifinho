using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour
{
    [Header("Arrays de Objetos")]
    public GameObject[] cards;
    public GameObject[] pos;
    public GameObject[] right, wrong;

    [Header("Listas de Objetos")]
    public List<int> cardsUsed;
    public List<int> posUsed;
    public List<GameObject> cardsFliped = new List<GameObject>();

    [Header("Variáveis de sorteio")]
    public int randCards;
    public int randPos;
    protected System.Random randomCards = new System.Random();
    protected System.Random randomPos = new System.Random();
    public int objRandPos;

    [Header("Contadores")]
    public int count;
    public int countForFinish;

    [Header("Variáveis de Armazenamento")]
    public int a;
    public int b;
    public int valor;
    public int nextLevel;

    [Header("Booleanas")]
    public bool objective = true;
    public bool roundFinished = false;
    public bool shuffleTime = false;

    [Header("Instancias")]
    public AudioClip btnClick;
    public GameObject keeper, newKeeper;
    protected Rounds round;
    public DifficultChoose difficult;

    void Start()
    {
        keeper = GameObject.Find("Keeper");
        RoundsSettings();
        DifficultSettings();
        InstatiateGame();
    }

    void Update()
    {
        GameLogic();
        Shuffle();
    }
    public virtual void RoundsSettings()
    {
        round = GameObject.Find("Rounds").GetComponent<Rounds>();
        round = GameObject.FindObjectOfType(typeof(Rounds)) as Rounds;

        for (int i = 0; i < right.Length; i++)
        {
            right[i].SetActive(false);
        }
    }

    public virtual void DifficultSettings()
    {
        difficult = GameObject.Find("DifficultManager").GetComponent<DifficultChoose>();

        switch (difficult.difficult)
        {
            case 1:
                valor = 6;
                break;

            case 2:
                valor = 8;
                break;
            case 3:

                valor = 10;
                break;
        }
    }

    public virtual void GameLogic()
    {
        if (count == 2)
        {
            if (a != b)
            {
                for (int i = 0; i < cardsFliped.Count; i++)
                {
                    round.finished = true;
                    shuffleTime = true;
                    right[round.indexR].SetActive(true);
                    right[round.indexR].GetComponent<Image>().color = Color.red;
                }
                Invoke("EndOfRound", 1);
                countForFinish++;
            }
            else
            {
                Invoke("EndOfRound", 1);
                round.finished = true;
                shuffleTime = true;
                right[round.indexR].SetActive(true);
                right[round.indexR].GetComponent<Image>().color = Color.green;
                countForFinish++;
            }

            a = 0;
            b = 0;
            count = 0;
            cardsFliped.Clear();
        }

        if (countForFinish >= 5)
        {
            Invoke("NextMinigame", 0.8f);
        }
    }
    public virtual void Back()
    {
        LoadingScreenManager.LoadScene(3);
        SoundManager.instance.PlaySingle(btnClick);
    }

    public virtual void Shuffle()
    {
        if (shuffleTime)
        {
            keeper = GameObject.Find("Keeper");
            newKeeper = Instantiate(keeper, keeper.gameObject.transform.position, keeper.gameObject.transform.rotation);
            Destroy(GameObject.Find("Keeper"));
            newKeeper.gameObject.name = "Keeper";
            shuffleTime = false;
        }
    }

    public virtual void InstatiateGame()
    {
        randCards = randomCards.Next(0, valor);
        randPos = randomPos.Next(0, valor);

        for (int i = 0; i < valor + 1; i++)
        {
            if (objective)
            {
                if (posUsed.Contains(randPos))
                {
                    randPos = randomPos.Next(0, valor);
                    i--;
                }
                else if (i <= 1)
                {
                    cardsUsed.Add(randCards);
                    posUsed.Add(randPos);
                    Instantiate(cards[cardsUsed[i]], pos[posUsed[i]].transform.position, pos[posUsed[i]].transform.rotation);
                }
                else
                {
                    objective = false;
                }
            }

            else
            {
                randCards = randomCards.Next(0, valor);
                randPos = randomPos.Next(0, valor);

                if (cardsUsed.Contains(randCards) && objective == false)
                {
                    randCards = randomCards.Next(0, valor);
                    i--;
                }
                else if (posUsed.Contains(randPos) && objective == false)
                {
                    randPos = randomPos.Next(0, valor);
                    i--;
                }
                else
                {
                    cardsUsed.Add(randCards);
                    posUsed.Add(randPos);
                    Instantiate(cards[cardsUsed[i - 1]], pos[posUsed[i - 1]].transform.position, pos[posUsed[i - 1]].transform.rotation);
                }
            }
        }
    }
    public virtual void EndOfRound()
    {
        objective = true;
        cardsUsed.Clear();
        posUsed.Clear();
        randCards = randomCards.Next(0, valor);
        randPos = randomPos.Next(0, valor);

            for (int i = 0; i < valor + 1; i++)
            {
                if (objective)
                {
                    if (posUsed.Contains(randPos))
                    {
                        randPos = randomPos.Next(0, valor);
                        i--;
                    }
                    else if (i <= 1)
                    {
                        cardsUsed.Add(randCards);
                        posUsed.Add(randPos);
                        Instantiate(cards[cardsUsed[i]], pos[posUsed[i]].transform.position, pos[posUsed[i]].transform.rotation);
                    }
                    else
                    {
                        objective = false;
                    }
                }

                else
                {
                    randCards = randomCards.Next(0, valor);
                    randPos = randomPos.Next(0, valor);

                    if (cardsUsed.Contains(randCards) && objective == false)
                    {
                        randCards = randomCards.Next(0, valor);
                        i--;
                    }
                    else if (posUsed.Contains(randPos) && objective == false)
                    {
                        randPos = randomPos.Next(0, valor);
                        i--;
                    }
                    else
                    {
                        cardsUsed.Add(randCards);
                        posUsed.Add(randPos);
                        Instantiate(cards[cardsUsed[i - 1]], pos[posUsed[i - 1]].transform.position, pos[posUsed[i - 1]].transform.rotation);
                    }
                }  
            }       
    }

    public virtual void NextMinigame()
    {
        LoadingScreenManager.LoadScene(nextLevel);
    }
}
