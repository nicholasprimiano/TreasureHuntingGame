using UnityEngine;
using System.Collections;

public class IgnoreWallCollision : MonoBehaviour
{

	public Transform bulletPrefab;

	void Start ()
	{
		Transform bullet = Instantiate (bulletPrefab) as Transform;
		Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
	}
}