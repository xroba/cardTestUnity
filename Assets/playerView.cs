using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerView : MonoBehaviour {

    PlayerModel playermodel;
    public  GameManager scriptgamemanager;
    List<int> playerhand;
    RaycastHit2D mousehit;
   


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
           Debug.Log(mousehit.collider.gameObject.tag);
           Debug.Log(mousehit.collider.gameObject.name);
       }
	
	}
}
