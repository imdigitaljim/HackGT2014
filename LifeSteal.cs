using UnityEngine;
using System.Collections;

public class LifeSteal : MonoBehaviour
{
    public float spawnDuration = 30f;
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
            c.GetComponent<PlayerControllerP1>().playerHealth += 1;
            GameObject.Find("Player2").GetComponent<PlayerControllerP2>().playerHealth -= 1;
        }
        else if (c.name == "Player2")
        {
            GetComponent<AudioSource>().Play();
            c.GetComponent<PlayerControllerP2>().playerHealth += 1;
            GameObject.Find("Player2").GetComponent<PlayerControllerP1>().playerHealth -= 1;
        }
        Destroy(gameObject, .1f);

    }
}
