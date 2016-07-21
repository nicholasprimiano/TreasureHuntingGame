using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

	Vector2 moveVector;
	Rigidbody2D myRigidbody;
	public float playerSpeedSet;
	public float shiftSpeed;
	private float playerSpeed;
	public AudioSource hurtSound;

	// Better practice to initalize a GetComponent<>() in start
	void Start ()
	{
		playerSpeed = playerSpeedSet;
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
		if (Input.GetKey (KeyCode.LeftShift)) {
			//SpriteRenderer playerSprite = GetComponent<SpriteRenderer> ();
			//playerSprite.color = new Color (.8f, .5f, 0f);
			playerSpeed = shiftSpeed;
		} else {
			playerSpeed = playerSpeedSet;
		}

	}
}

