using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Treasure : MonoBehaviour
{

	public Text textbuffer;
	public Transform PlayerObject;
	public Transform Hint1;
	public Transform Hint2;
	public Transform Hint3;
	public Transform Hint4;
	public Transform Hint5;
	public Transform Treasure1;
	public Door door;
	public Key key;
	public bool playerWin = false;
	private bool playable = true;
	private bool hasPlayed = false;
	private bool playable2 = true;
	private bool hasPlayed2 = false;
	private bool playable3 = true;
	private bool hasPlayed3 = false;
	private bool playable4 = true;
	private bool hasPlayed4 = false;
	private bool playable5 = true;
	private bool hasPlayed5 = false;


	// Update is called once per frame
	void Update ()
	{

		AudioSource notification = GetComponent<AudioSource> ();
		
		if (!door.nearDoor) {
			textbuffer.text = "Treasure is waiting for you somewhere.";
		}
		if ((PlayerObject.position - Hint1.position).magnitude < 25f) {
			textbuffer.text = "SHOOT!!!";
		} else if ((PlayerObject.position - Hint5.position).magnitude < 20f) {
			if (!notification.isPlaying && playable) {
				notification.PlayOneShot (notification.clip);
				hasPlayed = true;
				playable = false;
			}
			textbuffer.text = "If you hear something strange...start shooting! Also fire is bad for your health.";
		} else if ((PlayerObject.position - Hint2.position).magnitude < 20f) {
			if (!notification.isPlaying && playable2) {
				notification.PlayOneShot (notification.clip);
				hasPlayed2 = true;
				playable2 = false;
			}
			if (key.hasKey) {
				textbuffer.text = "I see you found the key.";
			} else {
				textbuffer.text = "I saw a key nearby.";
			}
		} else if ((PlayerObject.position - Hint3.position).magnitude < 20f) {
			if (!notification.isPlaying && playable3) {
				notification.PlayOneShot (notification.clip);
				hasPlayed3 = true;
				playable3 = false;
			}
			textbuffer.text = "I am sure you can find the treasure if you choose a different path....";
		} else if ((PlayerObject.position - Hint4.position).magnitude < 20f) {
			textbuffer.text = "Almost there!";
			if (!notification.isPlaying && playable4) {
				notification.PlayOneShot (notification.clip);
				hasPlayed4 = true;
				playable4 = false;
			}
		} else if ((PlayerObject.position - Treasure1.position).magnitude < 15f) {
			if (!notification.isPlaying && playable5) {
				notification.PlayOneShot (notification.clip);
				hasPlayed5 = true;
				playable5 = false;
			}
			textbuffer.text = "Press [Z] to loot the treasure!";
			if (Input.GetKeyDown (KeyCode.Z)) {
				playerWin = true;
				SceneManager.LoadScene ("Win Screen");
			}
		}

		if ((PlayerObject.position - Hint5.position).magnitude > 20f && hasPlayed) {
			playable = true;
			hasPlayed = false;
		}
		if ((PlayerObject.position - Hint2.position).magnitude > 20f && hasPlayed2) {
			playable2 = true;
			hasPlayed2 = false;
		}
		if ((PlayerObject.position - Hint3.position).magnitude > 20f && hasPlayed3) {
			playable3 = true;
			hasPlayed3 = false;
		}
		if ((PlayerObject.position - Hint4.position).magnitude > 20f && hasPlayed4) {
			playable4 = true;
			hasPlayed4 = false;
		}
		if ((PlayerObject.position - Treasure1.position).magnitude > 15f && hasPlayed5) {
			playable5 = true;
			hasPlayed5 = false;
		}

	}
}
