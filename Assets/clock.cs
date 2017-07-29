using UnityEngine;
using System.Collections;

public class clock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		zz = 0.0f;
	}
	public float zz ;
	// Update is called once per frame
	void FixedUpdate () {
		//旋转角度（增加）


		transform.Rotate(new Vector3(0,0,zz+Time.deltaTime*200.0f));
	}
}
