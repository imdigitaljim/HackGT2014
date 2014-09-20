using UnityEngine;
using System.Collections;

public class P2Health : MonoBehaviour {

    private PlayerControllerP2 player2;
    private dfTiledSprite bar;
	// Use this for initialization
	void Start () 
    {
        player2 = GameObject.Find("Player2").GetComponent<PlayerControllerP2>();
        bar = GetComponent<dfTiledSprite>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        bar.FillAmount = player2.playerHealth / 10f;
        
	}
}
