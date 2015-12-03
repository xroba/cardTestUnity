using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerView : MonoBehaviour {

    PlayerModel playermodel;
    public  GameManager scriptgamemanager;
    List<int> playerhand;

   


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
	
	}
}
