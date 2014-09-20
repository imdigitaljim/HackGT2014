using UnityEngine;
using System.Collections;

public class PlayerControllerP1 : MonoBehaviour {

    public float speed = 2;
    public int playerHealth;
    private Transform player;
    public Transform shot;
	// Use this for initialization
	void Start () 
    {
        playerHealth = 10;
        player = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        rigidbody2D.velocity = Vector2.zero;
        KeyPressMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shot, new Vector3(player.position.x, player.localPosition.y, player.position.z), player.rotation);
        }
    }


    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name.Contains("ShotP2"))
        {
            Debug.Log("P1 is hit");
            playerHealth -= 1;
            Destroy(c.gameObject);
        }
    }
    void KeyPressMovement()
    {
        float x = Input.GetAxisRaw("P1Horizontal");
        float y = Input.GetAxisRaw("P1Vertical");

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
