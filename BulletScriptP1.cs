using UnityEngine;
using System.Collections;
using System;

public class BulletScriptP1 : MonoBehaviour {

    private Transform bullet;
    private tk2dSprite image;
    private bool isMoving;
    private float speed = -.3f;
    private float range = 1;
    private bool longshot;

	void Start () 
    {
        longshot = GameObject.Find("Player1").GetComponent<PlayerControllerP1>().rangeBoost;
        if (longshot)
        {
            range = 3;
        }

        bullet = GetComponent<Transform>();
        bullet.Translate(0, -1f, 0);
        Invoke("LeaveDecal", range);
        isMoving = true;
        image = GetComponent<tk2dSprite>();
	}
    void Update()
    {
        if (isMoving)
        {
            bullet.Translate(0, speed - Convert.ToInt32(longshot) * .5f, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "WorldObject")
        {
            Destroy(gameObject);
        }
    }
    void LeaveDecal()
    {
        isMoving = false;
        image.spriteId = 7;
        image.scale = new Vector3(.5f, .5f, 1);
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject, 5);
    }

}
