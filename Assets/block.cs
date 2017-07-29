using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {

    static float xdir = 1;
    static float ydir = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x <= -2)
            xdir = -1;
        if (gameObject.transform.position.x >= 5)
            xdir = 1;

        if (gameObject.transform.position.y <= -2.5)
            ydir = 1;
        if (gameObject.transform.position.y >= 2.5)
            ydir = -1;

	    gameObject.transform.Translate(0.02f*xdir, 0.02f*ydir, 0);
	}
}
