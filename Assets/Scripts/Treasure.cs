using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Treasure : MonoBehaviour
{

	public Text textbuffer;
	public Transform PlayerObject;
	public Transform Hint1;
	public Transform Hint2;
	public Transform Hint3;
	public Transform Hint4;
	public Transform Hint5;
	public Transform Treasure1;
	public Door door;
	// Update is called once per frame
	void Update ()
	{
		if (!door.nearDoor) {
			textbuffer.text = "Treasure is waiting for you somewhere";
		}

		if ((PlayerObject.position - Hint1.position).magnitude < 25f) {
			textbuffer.text = "SHOOT!!!";
		} else if ((PlayerObject.position - Hint5.position).magnitude < 20f) {
			textbuffer.text = "If you hear somthing strange...start shooting! Also fire is bad fo your health.";
		} else if ((PlayerObject.position - Hint2.position).magnitude < 20f) {
			textbuffer.text = "I saw a key nearby.";
		} else if ((PlayerObject.position - Hint3.position).magnitude < 20f) {
			textbuffer.text = "I am sure you can get there if you choose a different path....";
		} else if ((PlayerObject.position - Hint4.position).magnitude < 20f) {
			textbuffer.text = "Almost, almost!.";
		} else if ((PlayerObject.position - Treasure1.position).magnitude < 15f) {
			textbuffer.text = "Press [Enter] to get treasure";
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene ("Win Screen");
			}
		}
	}
}
