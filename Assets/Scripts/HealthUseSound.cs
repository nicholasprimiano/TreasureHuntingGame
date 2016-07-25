using UnityEngine;
using System.Collections;

public class HealthUseSound : MonoBehaviour
{
	public Health health;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q) && health.hasHealth) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}
