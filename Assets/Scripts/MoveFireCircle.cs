using UnityEngine;
using System.Collections;

public class MoveFireCircle : MonoBehaviour
{

	float angle = 0;
	float speed = (2 * Mathf.PI) / 5;
	public float radius = 10;
	float x;
	float y;
	float initalX;
	float initalY;

	void Start ()
	{
		initalX = transform.position.x;
		initalY = transform.position.y;
	}

	void Update ()
	{
		angle += speed * Time.deltaTime; 
		x = Mathf.Cos (angle) * radius;
		y = Mathf.Sin (angle) * radius;
		transform.position = new Vector3 (x + initalX, y + initalY, transform.position.z);
	}


}
