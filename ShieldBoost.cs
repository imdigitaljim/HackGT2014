using UnityEngine;
using System.Collections;

public class ShieldBoost : MonoBehaviour
{
    public float spawnDuration = 10f;
    public float shieldLength = 10f;
    private float elapsed = 0;
    private bool isPickedUp;
    // Use this for initialization
    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPickedUp)
        {
            elapsed += Time.deltaTime;
            if (elapsed > spawnDuration)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            elapsed += Time.deltaTime;
            if (elapsed > shieldLength)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "Player1")
        {
            isPickedUp = true;
            if (c.GetComponent<PlayerControllerP1>().shieldBoost)
            {
                c.GetComponent<PlayerControllerP1>().shieldTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP1>().shieldBoost = true;
                transform.parent = c.transform;
                SetShield();
            }
        }
        else if (c.name == "Player2")
        {
            isPickedUp = true;
            if (c.GetComponent<PlayerControllerP2>().shieldBoost)
            {
                c.GetComponent<PlayerControllerP2>().shieldTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP2>().shieldBoost = true;
                transform.parent = c.transform;
                SetShield();
            }
        }
        else if (c.tag == "WorldObject")
        {
            Destroy(gameObject);
        }

    }
    void SetShield()
    {
        tk2dSprite shield = GetComponent<tk2dSprite>();
        GetComponent<CircleCollider2D>().isTrigger = false;
        shield.spriteId = 12;
        shield.scale = new Vector3(1, 1);
        GetComponent<CircleCollider2D>().radius = 1;
        transform.localPosition = Vector3.zero;
        elapsed = 0;
    }
}
