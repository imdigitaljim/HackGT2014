using UnityEngine;
using System.Collections;

public class P1Health : MonoBehaviour {

    private PlayerControllerP1 player1;
    private dfTiledSprite bar;
    // Use this for initialization
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<PlayerControllerP1>();
        bar = GetComponent<dfTiledSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.FillAmount = player1.playerHealth / 10f;

    }
}
