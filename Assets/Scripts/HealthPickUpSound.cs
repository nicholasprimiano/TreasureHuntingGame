using UnityEngine;
using System.Collections;

public class HealthPickUpSound : MonoBehaviour
{

	public Health health;
	private bool playOnce = true;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q) && health.hasHealth && playOnce) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.PlayOneShot (audio.clip);
			playOnce = false;
		}
	}
}
