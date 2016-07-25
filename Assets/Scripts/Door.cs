using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	
	public Key playerKey;
	public Transform player;
	public Treasure textbuffer;
	public bool nearDoor = false;
	private bool playOnceOpen = true;
	private bool doorOpening = false;
	public float moveDistance = 42f;
	private Vector3 initalPos;
	private bool canPlay = true;

	// Use this for initialization
	void Start ()
	{
		initalPos = transform.position; 
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		nearDoor = false;
		if ((player.transform.position - transform.position).magnitude <= 20f && playerKey.hasKey) {
			textbuffer.textbuffer.text = "Opened the door!";
			if (playOnceOpen) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.PlayOneShot (audio.clip);
				playOnceOpen = false;
			}
			doorOpening = true;
			playerKey.keyImage.SetActive (false);
		}

		if ((player.transform.position - transform.position).magnitude <= 20f && canPlay) {
			textbuffer.textbuffer.text = "The door is locked. Find the key";
			nearDoor = true;
			GameObject lockedDoor = GameObject.FindGameObjectWithTag ("DoorLocked");
			AudioSource audio = lockedDoor.GetComponent<AudioSource> ();
			if (!audio.isPlaying)
				audio.PlayOneShot (audio.clip);
		}

		if (doorOpening && Mathf.Abs (transform.position.y - initalPos.y) <= moveDistance) {
			openDoor ();
		}
	}

	void openDoor ()
	{
		transform.position -= new Vector3 (0, transform.position.y + .01f, 0);
		canPlay = false;
	}
}
