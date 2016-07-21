﻿using UnityEngine;
using System.Collections;
using System.Net;
using UnityEngineInternal;


public class Shoot : MonoBehaviour
{

	public Rigidbody2D bulletPrefab;
	public float attackSpeed = .5f;
	public float coolDown;
	public float bulletSpeed = 500;
	public float yValue;
	// Offset  
	public float xValue;
	// offset

	void start ()
	{
		 
	}

	void Update ()
	{
		if (Time.time >= coolDown) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Fire ();
			}
		}
	}


	//2D shooter tutorial
	void Fire ()
	{
		//Debug.Log ("Fire!");
		//Make bullet object
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
		Rigidbody2D bPrefab = Instantiate (bulletPrefab, new Vector3 (transform.position.x + xValue, transform.position.y + yValue, transform.position.z), transform.rotation) as Rigidbody2D;
		bPrefab.AddForce (transform.right * bulletSpeed, ForceMode2D.Impulse);
		coolDown = Time.time + attackSpeed;
	
	}

}
