using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	// Use this for initialization
    public int tpIndex = 0;
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D c)
    {

        Vector3[] tpPosition = new[] {
            new Vector3(-27, -15),
            new Vector3(27, -15),
            new Vector3(-27, 15),
            new Vector3(27, 15)
        };
        int randomTP = Random.Range(0, 3);
        while (randomTP == tpIndex)
        {
            randomTP = Random.Range(0, 3);
        }
        c.transform.position = tpPosition[randomTP];
    }
}
