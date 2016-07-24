﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditorInternal;


public class RestartScript : MonoBehaviour
{

	private GameObject timer;
	public bool didRestart = false;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("PlayerMoving");
			//restart game timer
			timer = GameObject.FindGameObjectWithTag ("Timer");
			Timer endTime = timer.GetComponent<Timer> ();
			endTime.timer = 0f;
			didRestart = true;
			Destroy (timer);
		}

	}
}
