using UnityEngine;
using System.Collections;

public class RestartSoundPlayer : MonoBehaviour
{

	static RestartSoundPlayer instance = null;

	// Use this for initialization
	void Start ()
	{
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			AudioSource auido = GetComponent<AudioSource> ();
			if (!auido.isPlaying) {
				auido.Play ();
			}
		}
	}
}