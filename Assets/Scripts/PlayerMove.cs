using UnityEngine;
using System.Collections;

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


	void Update ()
	{

		if (Input.GetKey (KeyCode.W)) {
			myRigidbody.velocity = transform.right * playerSpeed;
		} 
		if (Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity = -transform.right * playerSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			//Rotate CCW
			transform.RotateAround (new Vector3 (transform.position.x, transform.position.y, transform.position.z), Vector3.forward, 5);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.RotateAround (new Vector3 (transform.position.x, transform.position.y, transform.position.z), Vector3.forward, -5);
			//Rotate CW
		}
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity *= 0.8f;
		}

	}

	void FixedUpdate ()
	{


	}
		
	// Update is called once per frame
	//	void Update ()
	//	{
	//		//Get X axis input
	//		float horizontal = Input.GetAxis ("Horizontal");
	//		//Get Y axis input
	//		float vertical = Input.GetAxis ("Vertical");
	//		//Make movement vector
	//		moveVector = new Vector2 (horizontal, vertical);
	//		//Normalize moveVector -> magnitude = 1
	//		if (moveVector.magnitude > 1f) {  //joystick control if mag > 1
	//			moveVector = moveVector.normalized;
	//		}
	//		//Rotate player
	//		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
	//		Vector3 dir = Input.mousePosition - pos;
	//
	//		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg; //inverse tan in degrees
	//		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	//	}
	//	//Best practice to get input in Update and
	//	//Use physics in FixedUpdate
	//	void FixedUpdate ()
	//	{
	//		//Move character and scale to speed
	//		myRigidbody.velocity = moveVector * playerSpeed;
	//	}
}

