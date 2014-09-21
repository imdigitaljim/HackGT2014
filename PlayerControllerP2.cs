﻿using UnityEngine;
using System.Collections;

public class PlayerControllerP2 : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public int playerHealth;

    private Transform player;
    public Transform shot;
    private OverlordControl overlord;

    private float cooldownTimer;
    public float speedTimer;
    public float rangeTimer;
    public float shieldTimer;
    public float monkeyTimer;

    public bool speedBoost;
    public bool rangeBoost;
    public bool shieldBoost;
    public bool hugeStatus;
    public bool monkeyBoost;

    private bool offCoolDown;
    public float weaponCoolDown;

    void Start()
    {
        speedTimer = 0;
        rangeTimer = 0;
        shieldTimer = 0;
        monkeyTimer = 0;
        weaponCoolDown = .3f;
        cooldownTimer = 0;

        shieldBoost = false;
        speedBoost = false;
        rangeBoost = false;
        hugeStatus = false;


        offCoolDown = true;



        playerHealth = 10;
        player = GetComponent<Transform>();
        overlord = GameObject.Find("OVERLORD").GetComponent<OverlordControl>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Vector2.zero;
        if (OverlordControl.gameTime > 2)
        {
            KeyPressMovement();
        }
        if (GameStart.combat && offCoolDown)
        {
            if (Input.GetKey(KeyCode.Keypad0) || Input.GetKey(KeyCode.RightShift))
            {
                Instantiate(shot, new Vector3(player.position.x, player.localPosition.y, player.position.z), player.rotation);
                GetComponent<AudioSource>().Play();
                offCoolDown = false;
            }
        }
        if (playerHealth <= 0)
        {
            Application.LoadLevel("player1win");
        }
        if (playerHealth > 10)
        {
            playerHealth = 10;
        }
        if (!offCoolDown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer > weaponCoolDown)
            {
                offCoolDown = true;
                cooldownTimer = 0;
            }
        }
        if (speedBoost)
        {
            speedTimer += Time.deltaTime;
            if (speedTimer > 10)
            {
                speedBoost = false;
                speedTimer = 0;
            }
        }
        if (rangeBoost)
        {
            rangeTimer += Time.deltaTime;
            if (rangeTimer > 10)
            {
                rangeBoost = false;
                rangeTimer = 0;
            }
        }
        if (shieldBoost)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer > 10)
            {
                shieldBoost = false;
                shieldTimer = 0;
            }
        }
        if (monkeyBoost)
        {
            monkeyTimer += Time.deltaTime;
            if (monkeyTimer > 10)
            {
                weaponCoolDown = .3f;
                monkeyBoost = false;
                monkeyTimer = 0;
            }
        }



        if (overlord.hugeRound)
        {
            if (!hugeStatus)
            {
                gameObject.transform.localScale = new Vector3(2, 2, 1);
                hugeStatus = true;
            }
        }
        else
        {
            if (hugeStatus)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                hugeStatus = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name.Contains("ShotP1"))
        {
            if (transform.childCount == 0)
            {
                playerHealth -= 1;
            }
            Destroy(c.gameObject);
        }

    }
    void KeyPressMovement()
    {
        float x = Input.GetAxisRaw("P2Horizontal");
        float y = Input.GetAxisRaw("P2Vertical");

        if (x != 0 || y != 0)
        {
            if (speedBoost)
            {
                rigidbody2D.velocity = new Vector2(x * speed * 1.5f, y * speed * 1.5f);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(x * speed, y * speed);
            }
            if (x < 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 270);
            }
            if (x > 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 90);
            }
            if (y > 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 180);
            }
            if (y < 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 0);
            }
        }
    }
}
