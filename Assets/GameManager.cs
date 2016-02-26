using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public enum PlayerTurn
{
    PLAYER1,
    PLAYER2,
    BOT
}

public class GameManager : MonoBehaviour {

    public GameObject Card;
    public PlayerTurn PlayerTurn;
    public Sprite[] ArrCardSprite;
    SpriteRenderer _srCard;
    readonly List<int> _cardList = new List<int>();
    public int Round;
    public int NbOfPlayers; 
    public bool IsMyTurn;
    public GameObject MainDeck;
   

    public bool deckHasCard { get { return _cardList.Count >0; }}

	// Use this for initialization
	void Awake () {
        ArrCardSprite = Resources.LoadAll<Sprite>("Sprites");
        Round = 0;
        IsMyTurn = true;
        NbOfPlayers = 2;

        //create the deck
        CreateDeck();

        //shuffle card
        ShuffleCards();

        ShowCards();
	}

    void Start()
    {
        PlayerTurn = PlayerTurn.PLAYER1;
    }

    public int PullCard(){

            int card = _cardList[0];
            _cardList.RemoveAt(0);

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
            _cardList.Add(i);   
        }
    }

    private void ShowCards()
    {
        int i = 0;
        float j = -5f;
        foreach (int mCard in _cardList)
        {
            GameObject myCard = Instantiate(Card, new Vector3(j, 0, i), Quaternion.identity) as GameObject;
            myCard.name = "card_" + _cardList[i];

           myCard.transform.SetParent(MainDeck.transform);
           
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
            int cardToSWap1 = _cardList[i];

            //launch the dice
            int cardswapper = Random.Range(0,51);
            int cardToSwap2 = _cardList[cardswapper];

            _cardList[i] = cardToSwap2;
            _cardList[cardswapper] = cardToSWap1;
            
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

        

       
    }

    public void NextTurn()
    {
        if (PlayerTurn.Equals(PlayerTurn.PLAYER1))
        {
            PlayerTurn = PlayerTurn.PLAYER2;
        }
        else
        {
            PlayerTurn = PlayerTurn.PLAYER1;
        }

    }

    public void GivePlayerturnCard()
    {
        //check player turn and take the gameObject
        GameObject oPlayerTurn = GameObject.Find(PlayerTurn.ToString());
        Debug.Log(oPlayerTurn.name);

        NextTurn();
        

    }

}
