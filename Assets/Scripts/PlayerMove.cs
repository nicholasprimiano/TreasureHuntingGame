using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{

	Vector2 moveVector;
	Rigidbody2D myRigidbody;
	public float playerSpeedSet;
	public float shiftSpeed;
	private float playerSpeed;
	public AudioSource hurtSound;
	public TrailRenderer trailRendererGreen;
	public TrailRenderer trailRendererRed;
	private float initialTime;
	private bool canSprint = true;
	private const float maxSprintTime = 2f;
	private const float coolDown = 5f;
	private bool counting = false;
	private float coolDownTimer;
	private bool coolingDown = false;

	// Better practice to initalize a GetComponent<>() in start
	void Start ()
	{
		playerSpeed = playerSpeedSet;
		myRigidbody = GetComponent<Rigidbody2D> ();
	}


	void Update ()
	{
		float currentTime = Time.time;

		if (Input.GetKey (KeyCode.W)) {
			myRigidbody.velocity = transform.right * playerSpeed;
		} 
		if (Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity = -transform.right * playerSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			//Rotate CCW
			transform.RotateAround (new Vector3 (transform.position.x, transform.position.y, transform.position.z), Vector3.forward, 3.5f);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.RotateAround (new Vector3 (transform.position.x, transform.position.y, transform.position.z), Vector3.forward, -3.5f);
			//Rotate CW
		}
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity *= 0.8f;
		}

		//Sprint Code
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			initialTime = Time.time;
			counting = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			counting = false;
			canSprint = false;
		}

		if (counting && (currentTime - initialTime) >= maxSprintTime) {
			canSprint = false;
		}

		if (currentTime - coolDownTimer >= coolDown) {
			canSprint = true;
		}
		Debug.Log (canSprint);
		if (Input.GetKey (KeyCode.LeftShift) && canSprint) {
			//attach red trail renderer to player
			//why is unity terrible there should be a class for this
			trailRendererRed.transform.parent = transform;
			trailRendererRed.transform.position = transform.position;
			trailRendererGreen.enabled = false;
			trailRendererRed.enabled = true;
			playerSpeed = shiftSpeed;
			coolDownTimer = Time.time;

		} else {
			trailRendererGreen.enabled = true;
			trailRendererRed.enabled = false;
			playerSpeed = playerSpeedSet;
		}
	}

}

