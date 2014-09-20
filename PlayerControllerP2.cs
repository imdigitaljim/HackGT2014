using UnityEngine;
using System.Collections;

public class PlayerControllerP2 : MonoBehaviour
{

    // Use this for initialization
    public float speed = 2;
    public int playerHealth;
    private bool offCoolDown;
    private Transform player;
    public Transform shot;
    private float cooldownTimer;
    public float weaponCoolDown;
    void Start()
    {
        cooldownTimer = 0;
        offCoolDown = true;
        playerHealth = 10;
        player = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Vector2.zero;
        KeyPressMovement();
        if (GameStart.combat && offCoolDown)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                Instantiate(shot, new Vector3(player.position.x, player.localPosition.y, player.position.z), player.rotation);
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
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name.Contains("ShotP1"))
        {
            playerHealth -= 1;
            Destroy(c.gameObject);
        }

    }
    void KeyPressMovement()
    {
        float x = Input.GetAxisRaw("P2Horizontal");
        float y = Input.GetAxisRaw("P2Vertical");

        if (x != 0 || y != 0)
        {

            rigidbody2D.velocity = new Vector2(x * speed, y * speed);
            if (x < 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 270);
            }
            else if (x > 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 90);
            }
            else if (y > 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 180);
            }
            else if (y < 0)
            {
                player.eulerAngles = new Vector3(player.rotation.x, player.rotation.y, 0);
            }
        }
    }
}
