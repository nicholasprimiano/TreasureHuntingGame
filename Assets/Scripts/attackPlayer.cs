using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour
{

	public Transform attackSprite;
	//Attacking sprite
	public Vector3 moveDist = new Vector3 (0, -1, 0);
	//distance attacking sprite moves per frame
	private bool onEnter = false;
	// has player entered trigger zone?

	void Update ()
	{
		if (onEnter) { //Attack when player enters trigger area
			attack ();	
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		onEnter = true;
	}


	void attack () //Move sprite every frame (hopfully towards  the player)
	{
		attackSprite.position = attackSprite.position + moveDist;
	}
}
