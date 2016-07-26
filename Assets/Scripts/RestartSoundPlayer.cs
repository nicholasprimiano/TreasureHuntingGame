using UnityEngine;
using System.Collections;

public class RestartSoundPlayer : MonoBehaviour
{

	static RestartSoundPlayer instance = null;
	private MusicPlayer musicPlayer;
	// Use this for initialization
	void Start ()
	{
		if (instance != null) {
			Destroy (gameObject);
			//print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
		musicPlayer = FindObjectOfType<MusicPlayer> ();
		musicPlayer.GetComponent<AudioSource> ().mute = true;
		//musicPlayer.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			AudioSource auido = GetComponent<AudioSource> ();
			if (!auido.isPlaying) {
				auido.Play ();
				//musicPlayer.gameObject.SetActive (true);
				musicPlayer.GetComponent<AudioSource> ().mute = false;
			}
		}
	}
}