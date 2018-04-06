using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManagerMG3 : ModelManager {

    [Header("Minigame3 Specifics")]
    public GameObject[] objectives;
    public GameObject posObj;
    public int randObj;
    protected System.Random randomObj = new System.Random();

    // Use this for initialization
    void Start () {
        keeper = GameObject.Find("Keeper");
        InstatiateGame();
        RoundsSettings();
        DifficultSettings();
    }
	
	// Update is called once per frame
	void Update () {
        GameLogic();
        Shuffle();
    }
    public override void EndOfRound()
    {
        MG3Rules();
        cardsUsed.Clear();
        posUsed.Clear();
        randCards = randomCards.Next(0, valor);
        randPos = randomPos.Next(0, valor);
        Destroy(GameObject.Find("itemObj"));


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

    public void MG3Rules()
    {
      
        randObj = randomObj.Next(0, valor);
        GameObject itemObj = Instantiate(objectives[randObj], posObj.transform.position, posObj.transform.rotation);
        itemObj.transform.SetParent(GameObject.Find("Keeper").transform, false);
        itemObj.name = "itemObj";
        count++;

        if(randObj == 1)
        {
            b = 1;
        }
        else if(randObj == 2)
        {
            b = 2; 
        }
        if (randObj == 3)
        {
            b = 3;
        }
        else if (randObj == 4)
        {
            b = 4;
        }
        if (randObj == 5)
        {
            b = 5;
        }
    }

    public override void DifficultSettings()
    {
        difficult = GameObject.Find("DifficultManager").GetComponent<DifficultChoose>();

        switch (difficult.difficult)
        {
            case 1:
                valor = 3;
                break;

            case 2:
                valor = 4;
                break;
            case 3:

                valor = 5;
                break;
        }
    }

    public override void InstatiateGame()
    {
        MG3Rules();
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
}
