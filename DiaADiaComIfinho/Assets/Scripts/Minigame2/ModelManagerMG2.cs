using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManagerMG2 : ModelManager {

    [Header("Minigame2 Specifics")]
    public AudioClip[] audioNarrations;
    public AudioSource audioToPlay;
    public int randAudios;
    protected System.Random randomAudios = new System.Random();

    void Start () {
        PlaySound();
        InstatiateGame();
        RoundsSettings();
        DifficultSettings();
    }
	
	void Update () {
        GameLogic();
        Shuffle();
    }

    public override void InstatiateGame()
    {
        randCards = randomCards.Next(0, valor);
        randPos = randomPos.Next(0, valor);

        for (int i = 0; i < valor; i++)
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
                    Instantiate(cards[cardsUsed[i]], pos[posUsed[i]].transform.position, pos[posUsed[i]].transform.rotation);
                }
            }
    }

    public override void GameLogic()
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
                Invoke("PlaySound", 1.3f);
                countForFinish++;
            }
            else
            {
                Invoke("EndOfRound", 1);
                Invoke("PlaySound", 1.3f);
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

    public override void EndOfRound()
    {
        cardsUsed.Clear();
        posUsed.Clear();
        randCards = randomCards.Next(0, valor);
        randPos = randomPos.Next(0, valor);

        for (int i = 0; i < valor; i++)
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
                Instantiate(cards[cardsUsed[i]], pos[posUsed[i]].transform.position, pos[posUsed[i]].transform.rotation);
            }
        }
    }

    public override void DifficultSettings()
    {
        difficult = GameObject.Find("DifficultManager").GetComponent<DifficultChoose>();

        switch (difficult.difficult)
        {
            case 1:
                valor = 4;
                break;

            case 2:
                valor = 5;
                break;
            case 3:

                valor = 6;
                break;
        }
    }

    public void PlaySound()
    {
        randAudios = randomAudios.Next(0, valor);
        audioToPlay.clip = audioNarrations[randAudios];
        audioToPlay.Play();
        count++;

        if(randAudios == 0)
        {
            Debug.Log("0");
            b = 0;
        }
        else if(randAudios == 1)
        {
            Debug.Log("1");
            b = 1;
        }
        else if (randAudios == 2)
        {
            Debug.Log("2");
            b = 2;
        }
        else if (randAudios == 3)
        {
            Debug.Log("3");
            b = 3;
        }
        else if (randAudios == 4)
        {
            Debug.Log("4");
            b = 4;
        }
        else if (randAudios == 5)
        {
            Debug.Log("5");
            b = 5;
        }
        else if (randAudios == 6)
        {
            Debug.Log("6");
            b = 6;
        }
        else if (randAudios == 7)
        {
            Debug.Log("7");
            b = 7;
        }
    }
}
