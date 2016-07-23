using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	private const float coolDown = 4f;
	private bool counting = false;
	private float coolDownTimer;
	public GameObject buttonUp;
	public GameObject buttonDown;
	public Text boost;
	public Text counter;
	private bool inputStart = false;
	// Better practice to initalize a GetComponent<>() in start
	void Start ()
	{
		playerSpeed = playerSpeedSet;
		myRigidbody = GetComponent<Rigidbody2D> ();

		boost.gameObject.SetActive (true);
		counter.gameObject.SetActive (false);
	}


	void Update ()
	{
		float currentTime = Time.time;

		if (Input.GetKey (KeyCode.W)) {
			myRigidbody.velocity = transform.right * playerSpeed;
		} 
		if (Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity = -transform.right * playerSpeed / 2;
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

			//button logic
			buttonUp.SetActive (true);
			buttonUp.SetActive (false);
			inputStart = true;
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			counting = false;
			canSprint = false;
		
			//button logic
			buttonUp.SetActive (false);
			buttonUp.SetActive (true);

		}

		if (counting && (currentTime - initialTime) >= maxSprintTime) {
			canSprint = false;
		}

		if (currentTime - coolDownTimer >= coolDown) {
			canSprint = true;
			boost.gameObject.SetActive (true);
			counter.gameObject.SetActive (false);
		} else if (!inputStart) {
			boost.gameObject.SetActive (true);
			counter.gameObject.SetActive (false);
		} else {
			float temp;
			boost.gameObject.SetActive (false);
			counter.gameObject.SetActive (true);
			temp = Mathf.Ceil (currentTime - coolDownTimer);
			//Very ugly hack TO count backwards can't change CD time
			if (temp == 1) {
				counter.text = "4";
			} else if (temp == 2) {
				counter.text = "3";
			} else if (temp == 3) {
				counter.text = "2";
			} else if (temp == 4) {
				counter.text = "1";
			}

		}

		if (Input.GetKeyDown (KeyCode.LeftShift) && canSprint) {
			coolDownTimer = Time.time;
		}

		//Debug.Log (canSprint);
		if (Input.GetKey (KeyCode.LeftShift) && canSprint) {
			counting = true;
			//attach red trail renderer to player
			//why is unity terrible there should be a class for this
			trailRendererRed.transform.parent = transform;
			trailRendererRed.transform.position = transform.position;
			trailRendererGreen.enabled = false;
			trailRendererRed.enabled = true;
			playerSpeed = shiftSpeed;

		} else {
			trailRendererGreen.enabled = true;
			trailRendererRed.enabled = false;
			playerSpeed = playerSpeedSet;

		}
	}

}

