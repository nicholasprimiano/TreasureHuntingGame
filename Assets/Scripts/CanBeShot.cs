using UnityEngine;
using System.Collections;

public class CanBeShot : MonoBehaviour
{
	public bool canBeShot = false;

	void OnTriggerEnter2D (Collider2D collider)
	{
		canBeShot = true;
	}
}
