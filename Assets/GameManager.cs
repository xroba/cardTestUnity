using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject Card;
    public Sprite[] ArrCardSprite;
    SpriteRenderer srCard;
    List<int> cardList = new List<int>();
    public int round;
    public int nbOfPlayers; 
    public bool isMyTurn;

    public bool deckHasCard { get { return cardList.Count >0; }}

	// Use this for initialization
	void Awake () {
        ArrCardSprite = Resources.LoadAll<Sprite>("Sprites");
        round = 0;
        isMyTurn = true;
        nbOfPlayers = 2;

        //create the deck
        CreateDeck();

        //shuffle card
        ShuffleCards();

        ShowCards();
	}

    public int PullCard(){

            int card = cardList[0];
            cardList.RemoveAt(0);

            // Debug.Log(card);

            GameObject CartToDelete = GameObject.Find("card_" + card);
            Destroy(CartToDelete);

            return card;
         
    }

    //private void GiveSixCardToBothPlayer()
    //{

    //    int startDeckList = cardList.Count;

    //    for (int i = 1; i < 13; i++)
    //    {
    //        int pickupCardIndex = LaunchDice(startDeckList);

    //        int cartToAdd = cardList[pickupCardIndex];
    //        cardList.RemoveAt(pickupCardIndex);

    //        if (IsOdd(i)) //player1
    //        {
    //            playerList.Add(cartToAdd);
    //        }
    //        else //player2
    //        {
    //           // player2List.Add(cartToAdd);
    //        }


    //        startDeckList--;
    //    }

    //}

    private void CreateDeck()
    {
        for (int i = 0; i < 51; i++)
        {
            cardList.Add(i);   
        }
    }

    private void ShowCards()
    {
        int i = 0;
        float j = -5f;
        foreach (int mCard in cardList)
        {
            GameObject myCard = Instantiate(Card, new Vector3(j, 0, 0), Quaternion.identity) as GameObject;
            myCard.name = "card_" + cardList[i];
            //srCard = myCard.GetComponent<SpriteRenderer>();
            //srCard.sprite = ArrCardSprite[cardList[i]];

            i++;
            j = j + 0.005f;
        }

    }

    private void ShuffleCards()
    {
        for (int i = 0; i < 51; i++)
        {
            int cardToSWap1 = cardList[i];

            //launch the dice
            int cardswapper = Random.Range(0,51);
            int cardToSwap2 = cardList[cardswapper];

            cardList[i] = cardToSwap2;
            cardList[cardswapper] = cardToSWap1;
            
        }

    }

    private int LaunchDice(int nb)
    {
        return Random.Range(0, nb);
    }

	// Update is called once per frame
    //public static bool IsOdd(int value)
    //{
    //    return value % 2 != 0;
    //}

    void Update ()
    {

        

        if (isMyTurn)
        {

        }
    }
}
