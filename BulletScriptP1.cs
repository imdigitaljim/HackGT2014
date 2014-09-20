using UnityEngine;
using System.Collections;

public class BulletScriptP1 : MonoBehaviour {

    private Transform bullet;
    private tk2dSprite image;
    private bool isMoving;
    public float speed = -.2f;
    public float range = 1f;
	void Start () 
    {
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
            bullet.Translate(0, speed, 0);
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
