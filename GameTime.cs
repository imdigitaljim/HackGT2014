using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour {

    private dfLabel time;
    // Use this for initialization
	void Start () 
    {
        time = gameObject.GetComponent<dfLabel>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        time.Text = OverlordControl.gameTime.RoundToNearest(1).ToString();
	}
}
