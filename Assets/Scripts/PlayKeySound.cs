using UnityEngine;
using System.Collections;

public class PlayKeySound : MonoBehaviour
{

	public Key key;
	private bool playOnce = true;

	void Update ()
	{
		if (key.hasKey && playOnce) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.PlayOneShot (audio.clip);
			playOnce = false;
		}
	}
}
