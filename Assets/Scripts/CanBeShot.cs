using UnityEngine;
using System.Collections;

public class CanBeShot : MonoBehaviour
{
	public bool canBeShot = false;

	void OnTriggerEnter2D (Collider2D collider)
	{
		canBeShot = true;
		if (collider.tag == "Player") {
			playSound ();
		}
	}

	void playSound ()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		if (!audio.isPlaying)
			audio.PlayOneShot (audio.clip);
	}
}
