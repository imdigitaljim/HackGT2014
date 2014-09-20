using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OverlordControl : MonoBehaviour
{

    // Use this for initialization
    public Transform barrier;
    public Transform lifesteal;
    public static float gameTime;
    public float lifeStealSpawnFrequency = 60;
    private int barrierCount = 0;
    private bool powerUpSpawned;
    private float powerUpCooldownCount;
    public float powerUpCooldown = 3;
    void Start()
    {
        powerUpCooldownCount = 0;
        powerUpSpawned = false;
        barrierCount = Random.Range(8, 20);
        for (int i = 0; i < barrierCount; i++)
        {
            float x = Random.Range(-26f, 26f);
            float y = Random.Range(-18f, 18f);

            while ((x < 3 && !(x <= -3)) && (y < 3 && !(y <= -3)))
            {
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
        if (!powerUpSpawned)
        {
            if (gameTime % lifeStealSpawnFrequency < 1 && gameTime > 0)
            {
                powerUpSpawned = true;
                float x = Random.Range(-26f, 26f);
                float y = Random.Range(-18f, 18f);
                Instantiate(lifesteal, new Vector3(x, y), Quaternion.identity);
            }
        }
        if (powerUpSpawned)
        {
            powerUpCooldownCount += Time.deltaTime;
            if (powerUpCooldownCount > powerUpCooldown)
            {
                powerUpCooldownCount = 0;
                powerUpSpawned = false;
            }
        }
    }
}
