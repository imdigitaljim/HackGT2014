using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OverlordControl : MonoBehaviour
{

    // Use this for initialization
    public Transform barrier;
    public Transform lifesteal;
    public Transform speedboost;
    public Transform range;
    public Transform shield;


    public static float gameTime;


    public float lifeStealSpawnFrequency;
    public float speedSpawnFrequency;
    public float rangeFrequency;
    public float shieldFrequency;

    private float powerUpCooldownCount;
    private int barrierCount = 0;
    private bool powerUpSpawned;
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
            if (gameTime % lifeStealSpawnFrequency < 1 && gameTime > 5)
            {
                powerUpSpawned = true;
                float x = Random.Range(-26f, 26f);
                float y = Random.Range(-18f, 18f);
                Instantiate(lifesteal, new Vector3(x, y), Quaternion.identity);
            }

            if (gameTime % speedSpawnFrequency < 1 && gameTime > 5)
            {
                powerUpSpawned = true;
                float x = Random.Range(-26f, 26f);
                float y = Random.Range(-18f, 18f);
                Instantiate(speedboost, new Vector3(x, y), Quaternion.identity);
            }
            if (gameTime % rangeFrequency < 1 && gameTime > 5)
            {
                powerUpSpawned = true;
                float x = Random.Range(-26f, 26f);
                float y = Random.Range(-18f, 18f);
                Instantiate(range, new Vector3(x, y), Quaternion.identity);
            }
            if (gameTime % shieldFrequency < 1 && gameTime > 5)
            {
                powerUpSpawned = true;
                float x = Random.Range(-26f, 26f);
                float y = Random.Range(-18f, 18f);
                Instantiate(shield, new Vector3(x, y), Quaternion.identity);
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
