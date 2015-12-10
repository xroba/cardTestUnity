using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerView : MonoBehaviour {

    PlayerModel playermodel;
    public  GameManager scriptgamemanager;
    List<int> playerhand;
    RaycastHit2D mousehit;
	bool scalingCard;
   


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
			if(mousehit.collider.gameObject.tag == "Card"){

				GameObject oCard = mousehit.collider.gameObject;
				string nameCard = oCard.name;


				scaleCard();
			} else {
				scalingCard = false;
				DescaleCard();
			}

           //Debug.Log(mousehit.collider.gameObject.tag);
           //Debug.Log(mousehit.collider.gameObject.name);

       }
	
	}

	void scaleCard ()
	{
		if (!scalingCard) {
			scalingCard = true;
			mousehit.collider.gameObject.transform.localScale = new Vector3 (
			mousehit.collider.gameObject.transform.localScale.x + 1,
			mousehit.collider.gameObject.transform.localScale.y + 1,
			mousehit.collider.gameObject.transform.localScale.z);
		}
	}

	void DescaleCard ()
	{
		throw new System.NotImplementedException ();
	}
}
