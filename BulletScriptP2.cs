using UnityEngine;
using System.Collections;

public class BulletScriptP2 : MonoBehaviour {

    private Transform bullet;
    public float speed = -.2f;
    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Transform>();
        bullet.Translate(0, -1f, 0);
        Destroy(gameObject, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        bullet.Translate(0, speed, 0);
    }

}
