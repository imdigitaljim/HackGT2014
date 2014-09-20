using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    private dfPanel start;
    private dfLabel startTxt;
    private float beginRound;
    private float timePassed;
    public static bool combat;
    // Use this for initialization
    void Start()
    {
        combat = false;
        beginRound = 3;
        start = GameObject.Find("StartPanel").GetComponent<dfPanel>();
        startTxt = gameObject.GetComponent<dfLabel>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = OverlordControl.gameTime.RoundToNearest(1);
        startTxt.Text = (beginRound - timePassed).ToString();
        if (beginRound - timePassed <= 0)
        {
            start.Hide();
            combat = true;
        }
    }
}
