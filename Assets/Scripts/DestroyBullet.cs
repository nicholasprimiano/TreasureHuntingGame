using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class DestroyBullet : MonoBehaviour
{

	void OnTriggerExit2D (Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
