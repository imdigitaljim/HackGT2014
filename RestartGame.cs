using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Invoke("NewLevel", 3f);
        }
    }
    void NewLevel()
    {
        if (Application.loadedLevelName != "intro")
        {
            Application.LoadLevel("intro");
        }
        else
        {
            Application.LoadLevel("main_arena");
        }
    }
}
