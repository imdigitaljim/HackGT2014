using UnityEngine;
using System.Collections;

public class RangeBoost : MonoBehaviour
{
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
            if (c.GetComponent<PlayerControllerP1>().rangeBoost)
            {
                c.GetComponent<PlayerControllerP1>().rangeTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP1>().rangeBoost = true;
            }
        }

        else if (c.name == "Player2")
        {
            GetComponent<AudioSource>().Play();
            if (c.GetComponent<PlayerControllerP2>().rangeBoost)
            {
                c.GetComponent<PlayerControllerP2>().rangeTimer = 0;
            }
            else
            {
                c.GetComponent<PlayerControllerP2>().rangeBoost = true;
            }
        }
        Destroy(gameObject, .1f);
    }
}
