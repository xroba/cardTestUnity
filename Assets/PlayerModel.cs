using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class PlayerModel : MonoBehaviour {

    //GameObject GM;
    public GameManager scriptGameManager;
    public List<int> handList;
    public int numberOfstartCard;
    public GameObject cardPrefab;
    public float marginCard;
    public float offset;
    Sprite[] ArrCardSprite;
    SpriteRenderer srCard;
    bool onGetCard;
    Vector3 LastCardPosition;
    public int score;
    public bool hasPlayed;
    private CardList oCard;

    void Awake()
    {
        LastCardPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        oCard = new CardList();
        //Debug.Log("lastcardPosition" + LastCardPosition);
    }

	// Use this for initialization
	void Start () {
        ArrCardSprite = scriptGameManager.ArrCardSprite;
        GetStartCards();
	    score = 0;
        onGetCard = false;
        
        
	}


    void GetStartCards()
    {
        for (int i = 0; i < numberOfstartCard; i++)
        {
            GetCard();
        }
    }

    public void GetCard()
    {

        if (!scriptGameManager.deckHasCard)
            return;

        int mCard = scriptGameManager.PullCard();

        var cartIndex = handList.Count;
        handList.Add(mCard);
 
        offset = LastCardPosition.x + marginCard ;

        //instanciate the prefab
        GameObject instanciateCard = Instantiate(cardPrefab, new Vector3(offset, transform.position.y, cartIndex), Quaternion.identity) as GameObject;
        srCard = instanciateCard.GetComponent<SpriteRenderer>();
        srCard.sprite = ArrCardSprite[mCard];

        //setup Card Player Hand
        CardScript cardScrip = instanciateCard.GetComponent<CardScript>();
        cardScrip.playerHand = scriptGameManager.PlayerTurn;

        //Position + name
        instanciateCard.transform.parent = this.transform;
		instanciateCard.name = "card_" + mCard;

        //retrieve data from Card Array by index mCard
        cardScrip.Value =  oCard.GetValue(mCard);
        cardScrip.Suit = oCard.GetSuit(mCard);

        //instantiate the card on the right of the player involved
        LastCardPosition = instanciateCard.transform.position;
    }

    //public void SetOnGetCardToTrue()
    //{
    //    onGetCard = true;
    //}

    public void PlayCard(GameObject oCard)
    {
        CardScript cardscript = oCard.GetComponent<CardScript>();
        cardscript.onPlay = true;
        cardscript.playerHand = scriptGameManager.PlayerTurn;

        scriptGameManager.NextTurn();
    }

    void Update()
    {
        if (scriptGameManager.IsMyTurn)
        {
           

        }
        else
        {
            Debug.Log("player joue");
            GetCard();
            scriptGameManager.Round++;
            scriptGameManager.IsMyTurn = true;

        }


       

    }



}
