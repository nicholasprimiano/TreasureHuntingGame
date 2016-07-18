using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if the player holds down W, move up
		if (Input.GetKey (KeyCode.W)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (0f, 35f, 0f) * Time.deltaTime;
			Debug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.D)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (30f, 0f, 0f) * Time.deltaTime;
			Debug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (-30f, 0f, 0f) * Time.deltaTime;
			Debug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.S)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (0f, -30f, 0f) * Time.deltaTime;
			Debug.Log (transform.position.y);
		}
	}
}

