using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private Transform player1;
    private Transform player2;
    private tk2dCamera camera;
    // Use this for initialization
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
        camera = GetComponent<tk2dCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player1.position.x > 16 || player1.position.x < -16
     || player1.position.y > 12 || player1.position.y < -12) ||
     (player2.position.x > 16 || player2.position.x < -16
     || player2.position.y > 12 || player2.position.y < -12))
        {
            if (camera.ZoomFactor > .16f)
            {
                camera.ZoomFactor -= .2f * Time.deltaTime;
            }
        }

        else if ((player1.position.x > 8 || player1.position.x < -8
            || player1.position.y > 6 || player1.position.y < -6) ||
            (player2.position.x > 8 || player2.position.x < -8
            || player2.position.y > 6 || player2.position.y < -6))
        {
            if (camera.ZoomFactor > .25f)
            {
                camera.ZoomFactor -= .2f * Time.deltaTime;
            }
        }
        else
        {
            if (camera.ZoomFactor < .5f)
            {
                camera.ZoomFactor += .2f * Time.deltaTime;
            }
        }

    }
}
