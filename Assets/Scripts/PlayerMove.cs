using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if the player holds down W, move up
		if (Input.GetKey (KeyCode.W)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (0f, 35f, 0f) * Time.deltaTime;
			//aDebug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.D)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (30f, 0f, 0f) * Time.deltaTime;
			//Debug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.A)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (-30f, 0f, 0f) * Time.deltaTime;
			//Debug.Log (transform.position.y);
		}
		if (Input.GetKey (KeyCode.S)) {
			// Time.deltaTime is the duration of the frame in second
			transform.position += new Vector3 (0f, -30f, 0f) * Time.deltaTime;
			//Debug.Log (transform.position.y);
		}

		//Rotate player
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - pos;
		dir.Normalize ();
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; //inverse tan in degrees
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	

	}





}

