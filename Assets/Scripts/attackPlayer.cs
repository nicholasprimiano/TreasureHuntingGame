using UnityEngine;
using System.Collections;

public class attackPlayer : MonoBehaviour
{

	public Transform attackSprite;
	public Vector3 moveDist = new Vector3 (0, -1, 0);
	private bool onEnter = false;

	void Update ()
	{
		if (onEnter) {
			attack ();	
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		onEnter = true;
	}


	void attack ()
	{
		attackSprite.position = attackSprite.position + moveDist;
	}
}
