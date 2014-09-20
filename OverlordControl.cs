using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OverlordControl : MonoBehaviour
{

    // Use this for initialization
    public Transform barrier;
    public static float gameTime;

    private int barrierCount = 0;
    void Start()
    {
        barrierCount = Random.Range(8, 20);
        for (int i = 0; i < barrierCount; i++)
        {
            float x = Random.Range(-26f, 26f);
            float y = Random.Range(-18f, 18f);

            while ((x < 3 && !(x <= -3)) && (y < 3 && !(y <= -3)))
            {
                Debug.Log("reroll");
                x = Random.Range(-20f, 20f);
                y = Random.Range(-18f, 18f);
            }
            Instantiate(barrier, new Vector3(x, y), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

    }
}
