using UnityEngine;
using System.Collections;

public class objectPlacement : MonoBehaviour
{

    public Transform barrier;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) > 0 || Mathf.Abs(rigidbody2D.velocity.y) > 0)
        {
            rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x * .7f,
                rigidbody2D.velocity.y * .7f);
        }

    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (OverlordControl.gameTime < 1)
        {
            Debug.Log("replace");
            float x = Random.Range(-26f, 26f);
            float y = Random.Range(-18f, 18f);

            while ((x < 3 && !(x <= -3)) && (y < 3 && !(y <= -3)))
            {
                x = Random.Range(-20f, 20f);
                y = Random.Range(-18f, 18f);
            }
            transform.position = new Vector3(x, y);
        }
    }
}
