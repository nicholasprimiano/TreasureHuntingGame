using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);

		if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody2D> ().velocity += new Vector2 (0f, 50f) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			GetComponent<Rigidbody2D> ().velocity += new Vector2 (0f, -50f) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity += new Vector2 (50f, 0f) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity += new Vector2 (-50f, 0f) * Time.deltaTime;
		}
	}
}
