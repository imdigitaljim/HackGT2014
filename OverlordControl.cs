using UnityEngine;
using System.Collections;

public class OverlordControl : MonoBehaviour {

	// Use this for initialization
    private int barrierCount = 0;
	void Start () 
    {
        barrierCount = Random.Range(5, 10);  
        for (int i = 0; i < barrierCount; i++)
        {

        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
