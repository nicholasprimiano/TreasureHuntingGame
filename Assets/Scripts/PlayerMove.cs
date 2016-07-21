using UnityEngine;
using System.Collections;


// Use this for initialization
//	void Start ()
//	{
//		Cursor.visible = true;
//	}
//
//	// Update is called once per frame
//	void Update ()
//	{
//		//if the player holds down W, move up
//		if (Input.GetKey (KeyCode.W)) {
//			// Time.deltaTime is the duration of the frame in second
//			transform.position += new Vector3 (0f, 35f, 0f) * Time.deltaTime;
//			//aDebug.Log (transform.position.y);
//		}
//		if (Input.GetKey (KeyCode.D)) {
//			// Time.deltaTime is the duration of the frame in second
//			transform.position += new Vector3 (30f, 0f, 0f) * Time.deltaTime;
//			//Debug.Log (transform.position.y);
//		}
//		if (Input.GetKey (KeyCode.A)) {
//			// Time.deltaTime is the duration of the frame in second
//			transform.position += new Vector3 (-30f, 0f, 0f) * Time.deltaTime;
//			//Debug.Log (transform.position.y);
//		}
//		if (Input.GetKey (KeyCode.S)) {
//			// Time.deltaTime is the duration of the frame in second
//			transform.position += new Vector3 (0f, -30f, 0f) * Time.deltaTime;
//			//Debug.Log (transform.position.y);
//		}

//		//Rotate player
//		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
//		Vector3 dir = Input.mousePosition - pos;
//		dir.Normalize ();
//		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; //inverse tan in degrees
//		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	

//}


public class PlayerMove : MonoBehaviour
{

	Vector2 moveVector;
	Rigidbody2D myRigidbody;
	public float playerSpeed;

	// Better practice to initalize a GetComponent<>() in start
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		//Get X axis input
		float horizontal = Input.GetAxis ("Horizontal");
		//Get Y axis input
		float vertical = Input.GetAxis ("Vertical");
		//Make movement vector
		moveVector = new Vector2 (horizontal, vertical);
		//Normalize moveVector -> magnitude = 1
		if (moveVector.magnitude > 1f) {  //joystick control if mag > 1
			moveVector = moveVector.normalized;
		}
		//Rotate player
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - pos;
		dir.Normalize ();
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; //inverse tan in degrees
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	//Best practice to get input in Update and
	//Use physics in Fixed update
	void FixedUpdate ()
	{
		//Move character and scale to speed
		myRigidbody.velocity = moveVector * playerSpeed;
	}




}

