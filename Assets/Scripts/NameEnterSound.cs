﻿using UnityEngine;
using System.Collections;

public class NameEnterSound : MonoBehaviour
{

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void playSound ()
	{
		AudioSource auido = GetComponent<AudioSource> ();
		auido.Play ();
	}

}
