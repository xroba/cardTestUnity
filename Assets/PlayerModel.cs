using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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


    void Awake()
    {
        LastCardPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Debug.Log("lastcardPosition" + LastCardPosition);
    }

	// Use this for initialization
	void Start () {
        ArrCardSprite = scriptGameManager.ArrCardSprite;
        GetStartCards();
	    score = 0;
        onGetCard = false;
        
	}


    //private void showCards()
    //{
    //    int i = 0;
    //    foreach (int card in handList)
    //    {
    //        float offSet = transform.position.x + marginCard + i;
    //        GameObject mCard = (GameObject)Instantiate(cardPrefab, new Vector3(offSet, transform.position.y, 0f), Quaternion.identity);
    //        srCard = mCard.GetComponent<SpriteRenderer>();
    //        srCard.sprite = ArrCardSprite[handList[i]];

    //        mCard.transform.parent = this.transform;
    //        i++;
    //    }
    //}

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

        GameObject instanciateCard = Instantiate(cardPrefab, new Vector3(offset, transform.position.y, cartIndex), Quaternion.identity) as GameObject;
        srCard = instanciateCard.GetComponent<SpriteRenderer>();
        srCard.sprite = ArrCardSprite[mCard];

        instanciateCard.transform.parent = this.transform;
		instanciateCard.name = "card_" + mCard;

        LastCardPosition = instanciateCard.transform.position;
    }

    //public void SetOnGetCardToTrue()
    //{
    //    onGetCard = true;
    //}

    void Update()
    {
        if (scriptGameManager.isMyTurn)
        {
           

        }
        else
        {
            Debug.Log("player joue");
            GetCard();
            scriptGameManager.round++;
            scriptGameManager.isMyTurn = true;

        }


       

    }



}
