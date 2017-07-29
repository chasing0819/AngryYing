using UnityEngine;
using System.Collections;

public class carmove : MonoBehaviour {
    static float dir = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.transform.position.x <= -2)
            dir = 1;
        if (gameObject.transform.position.x >= 5)
            dir = -1;

        gameObject.transform.Translate(0.01f*dir, 0, 0);

	}
}
