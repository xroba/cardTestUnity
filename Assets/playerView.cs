using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerView : MonoBehaviour {

    PlayerModel playermodel;
    public  GameManager scriptgamemanager;
    List<int> playerhand;
    RaycastHit2D mousehit;
    public GameObject cardCurrentlyScale;
    private Transform[] transforms;
   
	// Use this for initialization
	void Start () {
        playermodel = GetComponent<PlayerModel>();
 
	}

    public void btnGetCard()
    {
        playermodel.GetCard();

        //scriptgamemanager.isMyTurn = false;
        scriptgamemanager.NextTurn();

    }
	
	// Update is called once per frame
	void Update () {
            //onMouseShowCard
            Vector2 mouseray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousehit = Physics2D.Raycast(mouseray, Vector2.zero);
            if (mousehit.collider != null)
            {

                Debug.Log(transform.gameObject.name);

                GameObject oCard = mousehit.collider.gameObject;

                    if (cardCurrentlyScale && cardCurrentlyScale.name != oCard.name)
                    {
                            DescaleCard(cardCurrentlyScale);
                            ScaleCard(oCard);
                    }
                    else
                    {
                        ScaleCard(oCard);
                    }

                    //click on the card
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("click on " + oCard.name);

                    //find the board of this player
                   // Transform board = transform.FindChild("BoardPlayer");
                    Transform board = transform.GetChild(0);
                    Vector3 boardPosition = board.position;

                       
                        oCard.transform.position = boardPosition;
                        oCard.transform.SetParent(board);

                   


                }

             }

            

            }


	void ScaleCard (GameObject oCard)
	{
        CardScript cardscript = oCard.GetComponent<CardScript>();
	    SpriteRenderer srCard = oCard.GetComponent<SpriteRenderer>();

	    srCard.sortingOrder = -1;

        if (!cardscript.isScale)
        {
            cardscript.isScale = true;
            this.cardCurrentlyScale = oCard;

            oCard.transform.localScale = new Vector3 (
            oCard.transform.localScale.x + 1,
            oCard.transform.localScale.y + 1,
            oCard.transform.localScale.z);
		}


	}

    void DescaleCard(GameObject oCard)
	{
        CardScript cardscript = oCard.GetComponent<CardScript>();
        if (cardscript.isScale)
        {
            cardscript.isScale = false;
            this.cardCurrentlyScale = null;

            SpriteRenderer srCard = oCard.GetComponent<SpriteRenderer>();

            srCard.sortingOrder = 0;

            oCard.transform.localScale = new Vector3(
           oCard.transform.localScale.x - 1,
           oCard.transform.localScale.y - 1,
           oCard.transform.localScale.z);

        }
		
	}
}
