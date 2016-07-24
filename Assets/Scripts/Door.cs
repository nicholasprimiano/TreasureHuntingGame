using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	
	public Key playerKey;
	public Transform player;
	public Treasure textbuffer;
	public bool nearDoor = false;
	private bool playOnceOpen = true;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{


		nearDoor = false;
		if ((player.transform.position - transform.position).magnitude <= 20f && playerKey.hasKey) {
			textbuffer.textbuffer.text = "Opened the door!";
			if (playOnceOpen) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.PlayOneShot (audio.clip);
				playOnceOpen = false;
			}

			transform.position += new Vector3 (transform.position.x, transform.position.y + 10f, transform.position.z);
			//gameObject.SetActive (false);
		}
		if ((player.transform.position - transform.position).magnitude <= 20f) {
			textbuffer.textbuffer.text = "The door is locked. Find the key";
			nearDoor = true;
			GameObject lockedDoor = GameObject.FindGameObjectWithTag ("DoorLocked");
			AudioSource audio = lockedDoor.GetComponent<AudioSource> ();
			if (!audio.isPlaying)
				audio.PlayOneShot (audio.clip);

		}
	}
}
