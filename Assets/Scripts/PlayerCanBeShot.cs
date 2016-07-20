using UnityEngine;
using System.Collections;

public class PlayerCanBeShot : MonoBehaviour
{
	public bool canBeShot = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			canBeShot = true;
		}
	}

}
