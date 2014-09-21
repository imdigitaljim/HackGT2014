using UnityEngine;
using System.Collections;

public class MonkeyBoost : MonoBehaviour {

    public float spawnDuration = 10f;
    private float elapsed = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > spawnDuration)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "Player1")
        {
            GetComponent<AudioSource>().Play();
            if (c.GetComponent<PlayerControllerP1>().monkeyBoost)
            {
                c.GetComponent<PlayerControllerP1>().monkeyTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP1>().monkeyBoost = true;
                c.GetComponent<PlayerControllerP1>().weaponCoolDown = .1f;
            }
        }
        else if (c.name == "Player2")
        {
            GetComponent<AudioSource>().Play();
            if (c.GetComponent<PlayerControllerP2>().monkeyBoost)
            {
                c.GetComponent<PlayerControllerP2>().monkeyTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP2>().monkeyBoost = true;
                c.GetComponent<PlayerControllerP2>().weaponCoolDown = .1f;
            }
        }
        Destroy(gameObject, .1f);
    }
}
