using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerView : MonoBehaviour {

    PlayerModel playermodel;
    public  GameManager scriptgamemanager;
    List<int> playerhand;
    RaycastHit2D mousehit;
    public GameObject cardCurrentlyScale;
	//bool scalingCard;
   


	// Use this for initialization
	void Start () {
        playermodel = GetComponent<PlayerModel>();
 
	}

   


    public void btnGetCard()
    {
        playermodel.GetCard();

        scriptgamemanager.isMyTurn = false;

    }
	
	// Update is called once per frame
	void Update () {

       Vector2 mouseray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       //Debug.Log(mouseray);
       mousehit = Physics2D.Raycast(mouseray, Vector2.zero);

       if (mousehit.collider != null)
       {
           GameObject oCard = mousehit.collider.gameObject;

           if (oCard.tag == "Card")
           {
				//string nameCard = oCard.name;

               if (cardCurrentlyScale && cardCurrentlyScale.name != oCard.name)
               {
                   DescaleCard(oCard);
                   scaleCard(oCard);
               }
               else
               {
                   scaleCard(oCard);
               }


                

			} else {
				//scalingCard = false;
				//DescaleCard();
			}

           //Debug.Log(mousehit.collider.gameObject.tag);
           //Debug.Log(mousehit.collider.gameObject.name);

       }
	
	}

	void scaleCard (GameObject oCard)
	{


        CardScript cardscript = oCard.GetComponent<CardScript>();


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

            oCard.transform.localScale = new Vector3(
           oCard.transform.localScale.x - 1,
           oCard.transform.localScale.y - 1,
           oCard.transform.localScale.z);

        }
		
	}
}
