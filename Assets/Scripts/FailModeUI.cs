using UnityEngine;
using System.Collections;

public class FailModeUI : MonoBehaviour
{
	private bool playOnce = true;

	// Use this for initialization
	void Start ()
	{
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log ("test");
		if (Input.GetKeyDown (KeyCode.F)) {
			gameObject.SetActive (true);
			if (playOnce) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
				playOnce = false;
			}

		}
	}
}
