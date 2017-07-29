using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartingPosition = transform.position;
		c = GetComponent<Camera> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing) {
			if (BirdToFollow != null) { //bird will be destroyed if it goes out of the scene
				var birdPosition = BirdToFollow.transform.position;
				float x = Mathf.Clamp (birdPosition.x, minCameraX, maxCameraX);
				float y = Mathf.Clamp (birdPosition.y, 0, 8);
				//camera follows bird's x position
				transform.position = new Vector3 (x, y, StartingPosition.z);

				float size = Mathf.Clamp (c.orthographicSize -= Time.deltaTime * 3, 6, 8);
				c.orthographicSize = size;

			} else {
				IsFollowing = false;
				float size = Mathf.Clamp(c.orthographicSize += Time.deltaTime*3, 6, 8);
				c.orthographicSize = size;
 
			} 

		}
		else {
			float size = Mathf.Clamp(c.orthographicSize += Time.deltaTime*3, 6, 8);
			c.orthographicSize = size;
		}

    }

    [HideInInspector]
    public Vector3 StartingPosition;
	public Camera c;

    private const float minCameraX = 0;
    private const float maxCameraX = 13;
    [HideInInspector]
    public bool IsFollowing;
    [HideInInspector]
    public Transform BirdToFollow;
}
