using UnityEngine;
using System.Collections;

public class FailModeUI : MonoBehaviour
{
	public bool failModeActive = false;

	// Use this for initialization
	void Start ()
	{
		//gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			failModeActive = true;
	
		}
	}
}
