﻿using UnityEngine;
using System.Collections;
using System.Net;


public class Shoot : MonoBehaviour
{

	public Rigidbody2D bulletPrefab;
	public float attackSpeed = .5f;
	public float coolDown;
	public float bulletSpeed = 500;
	public float yValue = 1f;
	// Offset  
	public float xValue = 0.2f;
	// offset

	void Update ()
	{
		if (Time.time >= coolDown) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Fire ();
			}
		}
	}



	void Fire ()
	{
		Debug.Log ("Fire!");
		Rigidbody2D bPrefab = Instantiate (bulletPrefab, new Vector3 (transform.position.x + xValue, transform.position.y + yValue, transform.position.z), transform.rotation) as Rigidbody2D;

		bPrefab.AddForce (transform.right * bulletSpeed);

		coolDown = Time.time + attackSpeed;
	
	}

}
